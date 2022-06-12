using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Services.BetsFetcher.Entities;

namespace TetBet.Server.Services.BetsFetcher.Mappers
{
    public class GenericBetProfile : Profile
    {
        private readonly IUnitOfWork _unitOfWork;

        public GenericBetProfile(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;

            CreateMap<ResourcesBetsConfiguration, ApplicationBets>()
                .ForMember(applicationBets => applicationBets.GenericBets,
                    option =>
                        option.MapFrom(resourcesBetsConfiguration =>
                            ResourcesBetsConfigurationToListOfGenericBets(resourcesBetsConfiguration)));
        }

        private IEnumerable<GenericBet> ResourcesBetsConfigurationToListOfGenericBets(
            ResourcesBetsConfiguration resourcesBetsConfiguration)
        {
            IEnumerable<GenericBet> genericBets = new List<GenericBet>();

            Sport contextSport = _unitOfWork
                .Sport
                .Get(sport => sport.Name.Equals(resourcesBetsConfiguration.Sport))
                .First();

            resourcesBetsConfiguration
                .ApplicationGenericBets
                .ToList()
                .ForEach(resourcesBet =>
                {
                    genericBets = genericBets.Append(new GenericBet
                    {
                        Sport = contextSport,
                        SportId = contextSport.Id,
                        Name = resourcesBet.GenericBetName,
                        Bets = ApplicationBetsListToBetsList(resourcesBet.BetsList)
                    });
                });

            return genericBets;
        }

        private ICollection<Bet> ApplicationBetsListToBetsList(IEnumerable<string> applicationBets)
        {
            ICollection<Bet> betsList = new List<Bet>();

            applicationBets
                .ToList()
                .ForEach(applicationBet =>
                {
                    betsList.Add(new Bet
                    {
                        BetName = applicationBet
                    });
                });

            return betsList;
        }
    }
}