using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Models.Entity;

namespace GokstadHageVenner.Repository.Repository_Interface
{
    public interface IArrangementRepository
    {
        Task<IEnumerable<Arrangement>> GetAllArrangementerAsync();
        Task<Arrangement> GetArrangementByIdAsync(int arrangementId);
        Task UpdateArrangementAsync(int arrangementId, Arrangement arrangement);
        Task DeleteArrangementAsync(int arrangementId);
        Task AddArrangementAsync(Arrangement arrangement);
    }

}