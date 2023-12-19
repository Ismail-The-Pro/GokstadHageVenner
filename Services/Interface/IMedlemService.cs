using GokstadHageVenner.Models.Entity;

namespace GokstadHageVenner.Services.Interface
{
    public interface IMedlemService
    {
        Medlem HentEtterId(int medlemsId);
        List<Medlem> HentAlle();
        void Lagre(Medlem medlem);
        void Slett(int medlemsId);
    }
    
}
