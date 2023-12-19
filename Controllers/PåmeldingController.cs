using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Services.Interface;
using GokstadHageVenner.Services;
using GokstadHageVenner.Models.DTO;
using System.Linq.Expressions;
using GokstadHageVenner.Mapper.Interface;
using GokstadHageVenner.Mapper;
using GokstadHageVenner.Repository.Repository_Interface;

namespace GokstadHageVenner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PåmeldingController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IPåmeldingService _påmeldingService;
        private readonly IMapper<Påmelding, PåmeldingDTO>_påmeldingMapper;
        private readonly IPåmeldingRepository _påmeldingRepository;

        public PåmeldingController(AppDbContext context, IPåmeldingService påmeldingService, IMapper<Påmelding, PåmeldingDTO> påmeldingMapper, IPåmeldingRepository påmeldingRepository)
        {
            _context = context;
            _påmeldingService = påmeldingService;
            _påmeldingMapper = påmeldingMapper;
            _påmeldingRepository = påmeldingRepository; ;
        }

        // POST: api/Påmelding
        [HttpPost]
        public async Task<ActionResult<PåmeldingDTO>> Påmelding(PåmeldingDTO påmeldingDTO)

        {
            var påmeldingEntity = _påmeldingMapper.MapToModel(påmeldingDTO, null);

            await _påmeldingRepository.PåmeldingAsync(påmeldingEntity);

            var resultDTO = _påmeldingMapper.MapToDTO(påmeldingEntity);

            return Ok(resultDTO);

        }

        // DELETE: api/Påmelding/5
        [HttpDelete("{arrangementId}/{medlemId}")]
        public async Task<IActionResult> Avmelding(int arrangementId, int medlemId)
        {
            await _påmeldingRepository.AvmeldingAsync(arrangementId, medlemId);

            return NoContent();
        }
        


    }
}
