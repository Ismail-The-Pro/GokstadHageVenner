using GokstadHageVenner.Models;
using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Models.Entity;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GokstadHageVenner.Services.Interface
{
    public interface IArrangementService
    {
       
        
            Task<IEnumerable<Arrangement>> GetAllArrangementerAsync();
            Task<Arrangement> GetArrangementByIdAsync(int arrangementId);
            Task<bool> UpdateArrangementAsync(int arrangementId, ArrangementDTO arrangementDTO);

             Task DeleteArrangementAsync(int arrangementId);
            Task AddArrangementAsync(Arrangement arrangement);
        

    }
}