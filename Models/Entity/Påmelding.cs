using System;
using Microsoft.EntityFrameworkCore;

namespace GokstadHageVenner.Models.Entity
{
    public class Påmelding
    {
        public int Id { get; set; }
        public int ArrangementId { get; set; }

        public int MedlemId { get; set; }
    }


}