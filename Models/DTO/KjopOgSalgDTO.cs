namespace GokstadHageVenner.Models.DTO
{
    public record KjopOgSalgDTO(
    
        int Id,
        string? Produkt,
        decimal Pris,
        int ArrangementId,
        int SelgerMedlemId,
        int KjoperMedlemId

    );
}