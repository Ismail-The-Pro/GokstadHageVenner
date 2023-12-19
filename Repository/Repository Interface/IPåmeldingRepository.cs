using GokstadHageVenner.Models.Entity;

namespace GokstadHageVenner.Repository.Repository_Interface
{
    public interface IPåmeldingRepository
    {
        Task PåmeldingAsync(Påmelding påmelding);
        Task AvmeldingAsync(int arrangementId, int medlemId);

    }
}
