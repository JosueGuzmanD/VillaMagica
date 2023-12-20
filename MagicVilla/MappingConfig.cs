using AutoMapper;
using MagicVilla.Models;
using MagicVilla.Models.Dto;

namespace MagicVilla
{
    public class MappingConfig: Profile
    {
        public MappingConfig()
        {
               CreateMap<Villa,VillaDto>();
               CreateMap<VillaDto, Villa>();
               CreateMap<VillaNumber,VillaNumberDto>().ReverseMap();
               CreateMap<VillaNumber, VillaNumberCreateDto>().ReverseMap();
               CreateMap<VillaNumber, VillaNumberUpdateDto>().ReverseMap();
               CreateMap<Villa, VillaCreateDto>().ReverseMap();
               CreateMap<Villa, VillaUpdateDto>().ReverseMap();


        }


    }
}
