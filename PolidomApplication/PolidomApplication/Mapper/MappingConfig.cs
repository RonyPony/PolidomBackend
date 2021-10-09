using AutoMapper;
using Polidom.Core.Models;
using Polidom.Data.Data.identity;

namespace PolidomApplication.Mapper
{
    public class MappingConfig : Profile
    {
        public MappingConfig()
        {
            CreateMap<Account, AccountToRegister>().ReverseMap();
            CreateMap<Account, AccountToUpdate>().ReverseMap();
        }
    }
}
