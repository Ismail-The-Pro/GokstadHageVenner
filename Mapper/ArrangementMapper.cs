using AutoMapper;
using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Mapper.Interface;
using System.Collections.Generic;
using System.Linq;

namespace GokstadHageVenner.Mapper
{
    public class ArrangementMapper : IMapper<Arrangement, ArrangementDTO>
    {
        

        public ArrangementDTO MapToDTO(Arrangement model)
        {
            return new ArrangementDTO
           (
               model.Id,
               model.Navn,
               model.Beskrivelse,
               model.Tidspunkt,
               model.Sted,
               model.Arrangementstype,
                model.ErKjopOgSalg
           );
        }


        public Arrangement MapToModel(ArrangementDTO dto, Arrangement arrangement)
        {
            return new Arrangement
            {
                Id = dto.Id,
                Navn = dto.Navn,
                Beskrivelse = dto.Beskrivelse,
                Tidspunkt = dto.Tidspunkt,
                Sted = dto.Sted,
                Arrangementstype = dto.Arrangementstype,
                ErKjopOgSalg = dto.ErKjopOgSalg
            };

        }
    }
}