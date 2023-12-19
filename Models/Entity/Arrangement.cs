using System;
using Microsoft.EntityFrameworkCore;

namespace GokstadHageVenner.Models.Entity
{

    public class Arrangement
    {
        public int Id { get; set; }
        public string Navn { get; set; }
        public string Beskrivelse { get; set; }
        public DateTime Tidspunkt { get; set; }
        public string Sted { get; set; }
        public string Arrangementstype { get; set; }
        public bool ErKjopOgSalg { get; set; }



    }

}

