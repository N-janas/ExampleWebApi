using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VideoGamesCompaniesAPI.Entities;
using VideoGamesCompaniesAPI.Models;

namespace VideoGamesCompaniesAPI
{
    public class GameCompanyMappingProfile : Profile
    {
        public GameCompanyMappingProfile()
        {
            CreateMap<GameCompany, GameCompanyDto>()
                .ForMember(m => m.City, c => c.MapFrom(s => s.HqAddress.City))
                .ForMember(m => m.Street, c => c.MapFrom(s => s.HqAddress.Street))
                .ForMember(m => m.PostalCode, c => c.MapFrom(s => s.HqAddress.PostalCode));

            CreateMap<Game, GameDto>();

            CreateMap<CreateGameCompanyDto, GameCompany>()
                .ForMember(gc => gc.HqAddress, c => c.MapFrom(dto => new HqAddress()
                { City = dto.City, Street = dto.Street, PostalCode = dto.PostalCode }));
        }
    }
}
