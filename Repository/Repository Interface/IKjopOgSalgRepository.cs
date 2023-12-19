using GokstadHageVenner.Models.Entity;

namespace GokstadHageVenner.Repository.Repository_Interface
{
    public interface IKjopOgSalgRepository
    {
        Task<IEnumerable<KjopOgSalg>> GetKjopOgSalgForArrangementAsync(int ArrangementId);
        Task<IEnumerable<KjopOgSalg>> GetKjopOgSalgForMedlemAsync(int medlemId);
        Task<KjopOgSalg> GetKjopOgSalgByIdAsync(int kjopOgSalgId);

    }
}
