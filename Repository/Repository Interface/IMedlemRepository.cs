using GokstadHageVenner.Models.Entity;

namespace GokstadHageVenner.Repository.Repository_Interface
{
    public interface IMedlemRepository
    {
        Medlem HentEtterId(int medlemId);
        List<Medlem> HentAlle();
        void Lagre(Medlem medlem);
        void Slett(int medlemsId);
    }
}
