using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Repository.Repository_Interface;
using Microsoft.EntityFrameworkCore;


namespace GokstadHageVenner.Repository
{
    public class PåmeldingRepository : IPåmeldingRepository
    {
        private readonly AppDbContext _context;
        IPåmeldingRepository påmeldingRepository;

        public PåmeldingRepository(AppDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task AvmeldingAsync(int arrangementId, int medlemId)
        {

            var påmelding = await _context.Påmeldinger
          .FirstOrDefaultAsync(p => p.ArrangementId == arrangementId && p.MedlemId == medlemId);


            if (påmelding != null)
            {

                _context.Påmeldinger.Remove(påmelding);
                await _context.SaveChangesAsync();
            }
            else
            {

                throw new InvalidOperationException("Feil ved avmelding. Påmelding ikke funnet.");

            }
        }
        public async Task PåmeldingAsync(Påmelding påmelding)
        {
            _context.Påmeldinger.Add(påmelding);
            await _context.SaveChangesAsync();
        }
    }
}
