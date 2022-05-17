using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using AutoMapper;
using TetBet.Infrastructure.Entities;
using TetBet.Server.Dtos;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;

namespace TetBet.Server.Application.Mappers.RapidApi
{
    public class FixtureOddsProfile : Profile
    {
        private const long HardCodedPreferredBookmakerId = 8; //  Bet365 from RapidApi
        
        private readonly IMapper _sportEventBetProfile;
        
        public FixtureOddsProfile(IMapper sportEventBetProfile)
        {
            _sportEventBetProfile = sportEventBetProfile;
        
            CreateMap<FixtureOdds, FixtureOddsDto>()
                .ForAllMembers(opts => opts
                    .MapFrom(odds => FixtureOddToSportEvent(odds)));
        }
        
        private FixtureOddsDto FixtureOddToSportEvent(FixtureOdds fixtureOdds)
        {
            IEnumerable<Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Bet> bets = fixtureOdds
                .Bookmakers
                .FirstOrDefault(bookmaker => bookmaker.Id == HardCodedPreferredBookmakerId)
                .Bets;
        
            return new FixtureOddsDto
            {
                FixtureId = fixtureOdds.Fixture.Id,
                AvailableBets = _sportEventBetProfile.Map<IEnumerable<SportEventBet>>(bets)
            };
        }
    }
}