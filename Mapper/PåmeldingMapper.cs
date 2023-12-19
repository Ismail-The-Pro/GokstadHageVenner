using GokstadHageVenner.Mapper.Interface;
using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Models.Entity;

namespace GokstadHageVenner.Mapper
{
    public class PåmeldingMapper : IMapper<Påmelding, PåmeldingDTO>
    {
        public PåmeldingDTO MapToDTO(Påmelding model)
        {
            return new PåmeldingDTO
            {
                Id = model.Id,
                ArrangamentID = model.ArrangementId,
                MedlemId = model.MedlemId
            };
        }
    
    
     

        public Påmelding MapToModel(PåmeldingDTO dto, Arrangement arrangement)
        {
            return new Påmelding
            {
                Id = dto.Id,
                ArrangementId = dto.ArrangamentID,
                MedlemId = dto.MedlemId
            };
        }
    }

}
