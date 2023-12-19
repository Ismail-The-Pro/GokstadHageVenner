using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Repository;
using GokstadHageVenner.Repository.Repository_Interface;
using GokstadHageVenner.Services.Interface;

namespace GokstadHageVenner.Services
{
    
    public class KjopOgSalgService : IKjopOgSalgService
    {
        private readonly IKjopOgSalgRepository _kjopOgSalgRepository;
        private readonly AppDbContext _dbContext;

        public KjopOgSalgService(IKjopOgSalgRepository kjopOgSalgRepository)
        {
            _kjopOgSalgRepository = kjopOgSalgRepository ?? throw new ArgumentNullException(nameof(kjopOgSalgRepository));
        }

        public async Task<KjopOgSalg> GetKjopOgSalgByIdAsync(int kjopOgSalgId)
        {
            return await _kjopOgSalgRepository.GetKjopOgSalgByIdAsync(kjopOgSalgId);
        }

        public async Task<IEnumerable<KjopOgSalg>> GetKjopOgSalgForArrangementAsync(int arrangementId)
        {
            return await _kjopOgSalgRepository.GetKjopOgSalgForArrangementAsync(arrangementId);
        }

        public async Task<IEnumerable<KjopOgSalg>> GetKjopOgSalgForMedlemAsync(int medlemId)
        {
            return await _kjopOgSalgRepository.GetKjopOgSalgForMedlemAsync(medlemId);  
        }
    }
}
