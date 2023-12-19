using GokstadHageVenner.Models.Entity;

namespace GokstadHageVenner.Services.Interface
{
    public interface IKjopOgSalgService
    {
        Task<IEnumerable<KjopOgSalg>> GetKjopOgSalgForArrangementAsync(int arrangementId);
        Task<IEnumerable<KjopOgSalg>> GetKjopOgSalgForMedlemAsync(int medlemId);
        Task<KjopOgSalg> GetKjopOgSalgByIdAsync(int kjopOgSalgId);

    }
}
