using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq.Expressions;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
using System.Collections.Generic;
using System.Threading.Tasks;
using GokstadHageVenner.Models.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;
using GokstadHageVenner.Repository.Repository_Interface;

namespace GokstadHageVenner.Repository
{
    public class KjopOgSalgRepository : IKjopOgSalgRepository
    {
        private readonly AppDbContext _dbContext;

        public KjopOgSalgRepository(AppDbContext dbContext)
        {
        _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<KjopOgSalg> GetKjopOgSalgByIdAsync(int kjopOgSalgId)
        {
            return await _dbContext.kjopOgSalg.FindAsync(kjopOgSalgId);
        }

        public async Task<IEnumerable<KjopOgSalg>> GetKjopOgSalgForArrangementAsync(int ArrangementId)
        {
            return await _dbContext.kjopOgSalg
                .Where(k => k.ArrangementId == ArrangementId)
                .ToListAsync();
        }

        public async Task<IEnumerable<KjopOgSalg>> GetKjopOgSalgForMedlemAsync(int medlemId)
        {
            return await _dbContext.kjopOgSalg.
                Where(k => k.MedlemId == medlemId)
                .ToListAsync();
        }   
    }
}

