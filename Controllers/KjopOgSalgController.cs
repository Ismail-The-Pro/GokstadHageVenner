using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Services.Interface;

namespace GokstadHageVenner.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KjopOgSalgController: ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IKjopOgSalgService _kjopOgSalgService;


        public KjopOgSalgController(AppDbContext context)
        {
            _context = context;
        }

        public KjopOgSalgController(IKjopOgSalgService kjopOgSalgService)
        {
            _kjopOgSalgService = kjopOgSalgService ?? throw new ArgumentNullException(nameof(kjopOgSalgService));
        }

        // GET: api/KjopOgSalg/5
        [HttpGet("{kjopOgSalgId}")]
        public async Task<ActionResult<KjopOgSalg>> GetKjopOgSalgById(int kjopOgSalgId)
        {
            var kjopOgSalg = await _kjopOgSalgService.GetKjopOgSalgByIdAsync(kjopOgSalgId);
            if (kjopOgSalg == null)
            {
                return NotFound();
            }

            return Ok(kjopOgSalg);
        }

        // GET: api/KjopOgSalg/ForArrangement/5
        [HttpGet("ForArrangement/{arrangementId}")]
        public async Task<ActionResult<IEnumerable<KjopOgSalg>>> GetKjopOgSalgForArrangement(int arrangementId)
        {
            var kjopOgSalg = await _kjopOgSalgService.GetKjopOgSalgForArrangementAsync(arrangementId);
            return Ok(kjopOgSalg);
        }

        //GET: api/KjopOgSalg/ForMedlem/5
        [HttpGet("ForMedlem/{medlemId}")]
        public async Task<ActionResult<IEnumerable<KjopOgSalg>>> GetKjopOgSalgForMedlem(int medlemId)
        {
            var kjopOgSalg = await _kjopOgSalgService.GetKjopOgSalgForMedlemAsync(medlemId);
            return Ok(kjopOgSalg);
        }


    }
}
