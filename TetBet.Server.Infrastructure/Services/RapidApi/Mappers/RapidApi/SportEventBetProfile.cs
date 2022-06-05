using System.Collections.Generic;
using AutoMapper;
using TetBet.Infrastructure.Entities;
using Bet = TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Bet;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Mappers.RapidApi
{
    public class SportEventBetProfile : Profile
    {
        private readonly IMapper _oddsMapper;

        public SportEventBetProfile(IMapper oddsMapper)
        {
            _oddsMapper = oddsMapper;

            CreateMap<Bet, SportEventBet>()
                .ForAllMembers(opts => opts
                    .MapFrom(bet => CreateSportEventBet(bet)));

            CreateMap<IEnumerable<Bet>, IEnumerable<SportEventBet>>();
            // !!! maybe this mapping won't work
        }

        private SportEventBet CreateSportEventBet(Bet bet)
            => new()
            {
                Bet = CreateBet(bet),
                Odds = _oddsMapper.Map<IEnumerable<Odd>>(bet.Odds)
            };

        private TetBet.Infrastructure.Entities.Bet CreateBet(Bet bet)
            => new()
            {
                BetName = bet.Name,
                RapidApiId = bet.Id
            };
    }
}