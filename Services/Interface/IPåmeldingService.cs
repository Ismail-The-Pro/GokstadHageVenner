using GokstadHageVenner.Models.Entity;

namespace GokstadHageVenner.Services.Interface
{
    public interface IPåmeldingService
    {
        Task PåmeldingAsync(Påmelding påmelding);
        Task AvmeldingAsync(int arrangementId, int medlemId);
    }
}