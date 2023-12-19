using GokstadHageVenner.Mapper.Interface;
using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Models.Entity;
using System.Reflection.Metadata.Ecma335;

namespace GokstadHageVenner.Mapper
{
    public class MedlemMapper : IMapper<Medlem, MedlemDto>
    {
        public MedlemDto MapToDTO(Medlem model)
        {
            return new MedlemDto
            {
                Id = model.Id,
                Navn = model.Navn,
                Email = model.Email,
                MedlemId = model.MedlemId
            };
        }

        public Medlem MapToModel(MedlemDto dto, Arrangement arrangement)
        {

            return new Medlem
            {
                Id = dto.Id,
                Navn = dto.Navn,
                Email = dto.Email,
                MedlemId = dto.MedlemId
            };
        }
    }
}

