using AutoMapper;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Mappers.RapidApi
{
    public class OddsProfile : Profile
    {
        public OddsProfile()
        {
            CreateMap<Odd, TetBet.Infrastructure.Entities.Odd>();
        }
    }
}