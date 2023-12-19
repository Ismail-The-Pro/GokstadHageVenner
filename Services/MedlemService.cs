using AutoMapper;
using GokstadHageVenner.Mapper;
using GokstadHageVenner.Models.DTO;
using GokstadHageVenner.Models.Entity;
using GokstadHageVenner.Repository.Repository_Interface;
using GokstadHageVenner.Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace GokstadHageVenner.Services
{
    public class MedlemService : IMedlemService

    {
        private readonly IMedlemRepository _medlemrepository;
        private readonly GokstadHageVenner.Mapper.Interface.IMapper<MedlemDto, Medlem> _medlemMapper;
        public MedlemService(IMedlemRepository medlemRepository, ,
IMedlemRepository medlemrepository,
Mapper.Interface.IMapper<MedlemDto, Medlem> medlemMapper)
        {
            _medlemrepository = medlemRepository;
            _medlemMapper = medlemMapper;
        }

        public List<Medlem> HentAlle()
        {
            return _medlemrepository.HentAlle();
            
        }

        public Medlem HentEtterId(int medlemsId)
        {
            return _medlemrepository.HentEtterId(medlemsId);
        }

        public void Lagre(Medlem medlem)
        {
            _medlemrepository.Lagre(medlem); 
        }

        public void Slett(int medlemsId)
        {
            _medlemrepository.Slett(medlemsId);
        }
    }
}
   
  