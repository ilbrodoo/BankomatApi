        using AutoMapper;
        using Bankomat.Api.Dto;
        using Bankomat.Api.Models;

namespace Bankomat.Api.Profiles
{
    public class FunzionalitaProfile : Profile
    {
        public FunzionalitaProfile()
        {
            CreateMap<Funzionalitum, FunzionalitaDto>();
        }
    }
}