using APIDOGUAX.Model;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiGuaxCore.Model;

namespace APIDOGUAX.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserCreateDTO, User>().ReverseMap();
            CreateMap<PhoneCreateDTO, Phone>().ReverseMap();
            CreateMap<AdressCreateDTO, Adress>().ReverseMap();
        }
    }
}
