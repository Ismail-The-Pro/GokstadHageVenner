using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GokstadHageVenner.Models.Entity
{
    public class Medlem
    {
        private int medlemId;

        public int Id { get; set; }

        [Required(ErrorMessage = "Navn er påkrevd")]
        public string Navn { get; set; }

        [Required(ErrorMessage = "Email er påkrevd")]
        public string Email { get; set; }

        [Required(ErrorMessage = "MedlemId er påkrevd")]
        public int MedlemId { get => medlemId; set => medlemId = value; }

        // Legg til andre egenskaper etter behov



        // Legg til flere asynkrone metoder etter behov
    }

}
