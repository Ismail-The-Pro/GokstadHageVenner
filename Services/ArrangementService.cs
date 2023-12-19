using AutoMapper;
using GokstadHageVenner.Mapper;
using GokstadHageVenner.Models;
using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Repository;
using GokstadHageVenner.Repository.Repository_Interface;
using GokstadHageVenner.Services.Interface;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using EntityState = Microsoft.EntityFrameworkCore.EntityState;

namespace GokstadHageVenner.Services
{
    public class ArrangementService : IArrangementService
    {
        private readonly IArrangementRepository _arrangemnetRepository;
        private readonly AppDbContext _dbContext;
        private ArrangementMapper _arrangementMapper;

        public ArrangementService(IArrangementRepository arrangementRepository, ArrangementMapper arrangementMapper)
        {
            _arrangemnetRepository = arrangementRepository;
            _arrangementMapper = arrangementMapper;
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

       

        public async Task<bool> UpdateArrangementAsync(int arrangementId, ArrangementDTO arrangementDTO)
        {
            var existingArrangment = await _arrangemnetRepository.GetArrangementByIdAsync(arrangementId);
            if (existingArrangment == null)
            {
                return false;
            }

            _arrangementMapper.MapToModel(arrangementDTO, existingArrangment);

            await _arrangemnetRepository.UpdateArrangementAsync(existingArrangment);

            return true;
        }
    }
    }
}