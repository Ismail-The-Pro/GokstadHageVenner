using System.ComponentModel.DataAnnotations;
using System;
using Microsoft.EntityFrameworkCore;

namespace GokstadHageVenner.Models.Entity
{
    public class KjopOgSalg
    {
        [Key]
        public int Id { get; set; }
        public string Produkt { get; set; }
        public decimal Pris { get; set; }

        // foreign keys 
        public int ArrangementId { get; set; }
        public int? SelgerMedlemId { get; set; }
        public int? KjoperMedlemId { get; set; }
        public int MedlemId { get; set; }

        // Navigation properties
        public Arrangement Arrangement { get; set; }
        public Medlem SelgerMedlem { get; set; }
        public Medlem KjoperMedlem { get; set; }

        public Medlem Medlem { get; set; }
    };


    // ... resten av koden for denne modellen


}

