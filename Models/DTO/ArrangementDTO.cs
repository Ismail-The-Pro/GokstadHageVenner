namespace GokstadHageVenner.Models.DTO
{
    public record ArrangementDTO(
        int Id,
        string? Navn,
        string? Beskrivelse,
        DateTime Tidspunkt,
        string? Sted,
        string? Arrangementstype,
        bool ErKjopOgSalg
        );

}
