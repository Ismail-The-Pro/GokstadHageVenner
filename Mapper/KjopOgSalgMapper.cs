using System.Collections.Generic;
using System.Linq;
using GokstadHageVenner.Mapper.Interface;
using GokstadHageVenner.Models;
using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Models.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace GokstadHageVenner.Mapper
{
    public class KjopOgSalgMapper : IMapper<KjopOgSalg, KjopOgSalgDTO>
    {
        public KjopOgSalgDTO MapToDTO(KjopOgSalg model)
        {
            return new KjopOgSalgDTO(
                Id: model.Id,
                Produkt: model.Produkt,
                Pris: model.Pris,
                ArrangementId: model.ArrangementId,
                SelgerMedlemId: model.SelgerMedlemId?? 00,
                KjoperMedlemId: model.KjoperMedlemId ?? 0
                );

        }

        public KjopOgSalg MapToModel(KjopOgSalgDTO dto, Arrangement arrangement)
        {

            return new KjopOgSalg
            {
                Id = dto.Id,
                Produkt = dto.Produkt,
                Pris = dto.Pris,
                ArrangementId= dto.ArrangementId,
                SelgerMedlemId = dto.SelgerMedlemId,
                KjoperMedlemId = dto.KjoperMedlemId


            };
         }
    }
}

