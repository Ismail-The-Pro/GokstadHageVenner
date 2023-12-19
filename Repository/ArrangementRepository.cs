using GokstadHageVenner.Repository.Repository_Interface;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using System.Linq.Expressions;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;
using System.Collections.Generic;
using System.Threading.Tasks;
using GokstadHageVenner.Models.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace GokstadHageVenner.Repository
{
    public class ArrangementRepository : IArrangementRepository
    {
        private AppDbContext _dbContext;

        public ArrangementRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddArrangamentAsync(Arrangement arrangement)
        {
            await _dbContext.Arrangementer.AddAsync(arrangement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task AddArrangementAsync(Arrangement arrangement)
        {
            _dbContext.Arrangementer.Add(arrangement);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteArrangementAsync(int arrangementId)
        {
            var arrangement = await _dbContext.Arrangementer.FindAsync(arrangementId);
            if (arrangement != null) 
            {
                _dbContext.Arrangementer.Remove(arrangement);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Arrangement>> GetAllArrangementerAsync()
        {
            return await _dbContext.Arrangementer.ToListAsync();
        }

        public async Task<Arrangement> GetArrangementByIdAsync(int arrangementId)
        {
            return await _dbContext.Arrangementer.FindAsync(arrangementId);
        }

        public async Task UpdateArrangementAsync(int arrangementId, Arrangement arrangement)
        {
            _dbContext.Entry(arrangement).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }

        
    }
}