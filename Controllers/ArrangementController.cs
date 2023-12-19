using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Services;
using GokstadHageVenner.Services.Interface;
using GokstadHageVenner.Models.Entity;
using Microsoft.EntityFrameworkCore.Storage;
using GokstadHageVenner.Mapper;
using GokstadHageVenner.Mapper.Interface;

namespace GokstadHageVenner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArrangementController : ControllerBase
    {


        private readonly IArrangementService _arrangementService;
        private readonly IMapper<Arrangement, ArrangementDTO> _arrangementMapper;

        public ArrangementController(IArrangementService arrangementService)
        {
            _arrangementService = arrangementService ?? throw new ArgumentNullException(nameof(arrangementService));
            _arrangementMapper = arrangementMapper ?? throw new ArgumentNullException(nameof(arrangementMapper));
        }

        // GET: api/Arrangement
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ArrangementDTO>>> GetArrangementer()
        {
            try
            {
                var arrangementer = await ArrangementService.GetAllArrangementerAsync();
                return Ok(arrangementer);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Servor Error: {ex.Message}");
            }


        }

        // GET: api/Arrangement/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ArrangementDTO>> GetArrangementById(int id)
        {
            try
            {
                var arrangement = await ArrangementService.GetArrangementByIdAsync(id);

                if (arrangement == null)
                {
                    return NotFound($"Arrangement with ID {id} not found");
                }

                return Ok(arrangement);

            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }



        }

        // PUT: api/Arrangement/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArrangement(int id, ArrangementDTO arrangementDTO)
        {
            try
            {
                if (id != arrangementDTO.Id)
                {
                    return BadRequest("ID mismatch between route parameter and payload");
                }

                var isUpdated = await ArrangementService.UpdateArrangementAsync(id, arrangementDTO);

                if (isUpdated)
                {
                    return NotFound($"Arrangement with ID {id} not found");
                }
                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }



        // POST: api/Arrangement
        [HttpPost]
        public async Task<ActionResult<ArrangementDTO>> PostArrangement(ArrangementDTO arrangementDTO)
        {
            try
            {
                var newArrangement = _arrangementMapper.MapToModel(arrangementDTO, new Arrangement());
                await _arrangementService.AddArrangementAsync(newArrangement);

                var createdDto = _arrangementMapper.MapToDTO(newArrangement);

                return CreatedAtAction(nameof(GetArrangementById), new { id = createdDto.Id }, createdDto);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occured: {ex.Message}");
            }
             
        }

        // DELETE: api/Arrangement/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArrangement(int id)
        {
            try
            {
                await _arrangementService.DeleteArrangementAsync(id);
                return NoContent();
            }
            catch(Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }


        }



    }
}