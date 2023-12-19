using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Repository.Repository_Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace GokstadHageVenner.Repository
{
    public class MedlemRepository : IMedlemRepository
    {
        private readonly AppDbContext _context;
        private readonly List<Medlem> _medlemmer = new List<Medlem>();

        public MedlemRepository(AppDbContext dbContext)
        {
            _context = dbContext;
            
        } 
        public List<Medlem> HentAlle()
        {
            return _context.Medlemmer.ToList();
        }

        public Medlem HentEtterId(int medlemId)
        {
            return _medlemmer.FirstOrDefault(m => m.Id == medlemId);
        }

        public void Lagre(Medlem medlem)
        {
             _medlemmer.Add(medlem);
        }

        public void Slett(int medlemsId)
        {
            var medlemSomSkalSlettes = _medlemmer.FirstOrDefault(m => m.Id == medlemsId);
            if (medlemSomSkalSlettes != null)
            {
                _medlemmer.Remove(medlemSomSkalSlettes);
            }

        }
    }
}
