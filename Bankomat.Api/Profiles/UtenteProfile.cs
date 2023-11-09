using AutoMapper;
using Bankomat.Api.Dto;
using Bankomat.Api.Models;

namespace Bankomat.Api.Profiles
{
    public class UtenteProfile : Profile
    {
        public UtenteProfile()
        {
            CreateMap<Utenti, UtentiDto>().ReverseMap();
            CreateMap<IEnumerable<UtentiDto>, IEnumerable<Utenti>>();
        }
    
    }
}
