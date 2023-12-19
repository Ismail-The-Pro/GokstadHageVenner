using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using GokstadHageVenner.Mapper.Interface;
using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Services.Interface;

[ApiController]
[Route("api/medlem")]
public class MedlemController : ControllerBase
{
    private readonly IMedlemService _medlemService;
    private readonly IMapper<Medlem, MedlemDto> _medlemMapper;

    public MedlemController(IMedlemService medlemService, IMapper<Medlem,MedlemDto> medlemMapper)
    {
        _medlemService = medlemService;
        _medlemMapper = medlemMapper;
    }

    [HttpGet("{medlemsId}")]
    public IActionResult HentMedlem(int medlemsId)
    {
        var medlem = _medlemService.HentEtterId(medlemsId);

        if(medlem == null)
        {
            return NotFound();
        }

        var medlemDto = _medlemMapper.MapToDTO(medlem);
        return Ok(medlemDto);
    }

    [HttpGet]
    public IActionResult HentAlleMedlemmer()
    {
        var alleMedlemmer = _medlemService.HentAlle();
        var alleMedlemmerDto = alleMedlemmer.Select(_medlemMapper.MapToDTO).ToList();

        return Ok(alleMedlemmerDto);
    }

    [HttpPost]
    public IActionResult LagreMedlem([FromBody] MedlemDto medlemDto)
    {
        if (medlemDto == null)
        {
            return BadRequest();
        }

        var medlem = _medlemMapper.MapToModel(medlemDto, null);

        _medlemService.Lagre(medlem);
        return CreatedAtAction(nameof(HentMedlem), new { medlemId = medlem.Id }, medlemDto);
    }

    [HttpDelete("{medlemsId}")]
    public IActionResult SlettMedlem(int medlemsId)
    {
        _medlemService.Slett(medlemsId);
        return NoContent();
    }

}