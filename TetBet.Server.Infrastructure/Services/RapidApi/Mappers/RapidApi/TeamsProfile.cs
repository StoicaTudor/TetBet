using System.Linq;
using AutoMapper;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using Country = TetBet.Infrastructure.Entities.Country;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Mappers.RapidApi
{
    public class TeamsProfile : Profile
    {
        public TeamsProfile(IUnitOfWork unitOfWork)
        {
            CreateMap<Team, SportEntity>()
                .ForMember(sportEntity => sportEntity.HomeStadium,
                    option
                        => option.MapFrom(team => team.StadiumName))
                .ForMember(sportEntity => sportEntity.Country,
                    option
                        => option.MapFrom(team => GetCountry(unitOfWork, team)))
                .ForMember(sportEntity => sportEntity.RapidApiId,
                    option
                        => option.MapFrom(team => team.Id))
                .ForMember(sportEntity => sportEntity.Id,
                    options => options.Ignore());
        }

        private Country GetCountry(IUnitOfWork unitOfWork, Team team)
            => unitOfWork
                .Country
                .Get(country => country.Name == team.Country)
                .First();
    }
}