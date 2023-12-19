using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Repository;
using GokstadHageVenner.Repository.Repository_Interface;
using GokstadHageVenner.Services.Interface;

namespace GokstadHageVenner.Services
{
    public class PåmeldingService : IPåmeldingService
    {
  
        private readonly AppDbContext _dbContext;
        private readonly IPåmeldingRepository _påmeldingRepository;

        public PåmeldingService(IPåmeldingRepository påmeldingRepository, AppDbContext dbContext)
        {
            _påmeldingRepository = påmeldingRepository ?? throw new ArgumentNullException(nameof(påmeldingRepository));
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task AvmeldingAsync(int arrangementId, int medlemId)
        {
            await _påmeldingRepository.AvmeldingAsync(arrangementId, medlemId);  
        }

        public async Task PåmeldingAsync(Påmelding påmelding)
        {
            await _påmeldingRepository.PåmeldingAsync(påmelding);
        }
    }
}

