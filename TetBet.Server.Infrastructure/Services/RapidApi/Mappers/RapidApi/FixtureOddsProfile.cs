using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities;
using TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities;
using Bet = TetBet.Server.Infrastructure.Services.RapidApi.Entities.FixtureOddsEntities.Bet;
using Odd = TetBet.Infrastructure.Entities.Odd;

namespace TetBet.Server.Infrastructure.Services.RapidApi.Mappers.RapidApi
{
    public class FixtureOddsProfile : Profile
    {
        private const long HardCodedPreferredBookmakerId = 8; //  Bet365 from RapidApi

        private readonly IUnitOfWork _unitOfWork;

        public FixtureOddsProfile(IMapper sportEventBetProfile, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            CreateMap<FixtureOdds, SportEvent>()
                .ForAllMembers(opts =>
                    opts.MapFrom(odds => FixtureOddsToListOfSportEventBets(odds))
                );
        }

        private SportEvent FixtureOddsToListOfSportEventBets(FixtureOdds fixtureOdds)
        {
            Bookmaker bookmaker = fixtureOdds
                .Bookmakers
                .FirstOrDefault(bookmaker => bookmaker.Id == HardCodedPreferredBookmakerId);

            if (bookmaker == null)
                return null;

            IEnumerable<Entities.FixtureOddsEntities.Bet> bets = bookmaker.Bets;

            SportEvent sportEvent = _unitOfWork
                .SportEvent
                .Get(sportEvent => sportEvent.RapidApiId == fixtureOdds.Fixture.Id)
                .First();

            List<GenericBet> genericBets = _unitOfWork
                .GenericBet
                .Get()
                .ToList();

            bookmaker
                .Bets
                .ToList()
                .ForEach(bet =>
                {
                    GenericBet foundGenericBet = genericBets.Find(genericBet => genericBet.Name.Equals(bet.Name));

                    if (foundGenericBet != null)
                    {
                        sportEvent.AvailableBets.Add(BetToSportEventBet(bet, sportEvent.Id
                        ));
                    }
                });

            return sportEvent;
        }

        private SportEventBet BetToSportEventBet(Bet bet, long sportEventId)
        {
            TetBet.Infrastructure.Entities.Bet betEntity =
                _unitOfWork
                    .Bet
                    .Get(bet1 => bet1.RapidApiId == bet.Id).First();

            return new()
            {
                SportEventId = sportEventId,
                Bet = _unitOfWork.Bet.Get(bet1 => bet1.RapidApiId == bet.Id).First(),
                Odds = BetToOddsCollection(bet, betEntity)
            };
        }

        private ICollection<Odd> BetToOddsCollection(Bet bet, TetBet.Infrastructure.Entities.Bet betEntity)
        {
            ICollection<Odd> odds = new List<Odd>();
            bet
                .Odds
                .ToList()
                .ForEach(odd =>
                    odds.Add(new Odd
                        {
                            Bet = betEntity,
                            Value = float.Parse(odd.Value),
                        }
                    )
                );

            return odds;
        }
    }
}