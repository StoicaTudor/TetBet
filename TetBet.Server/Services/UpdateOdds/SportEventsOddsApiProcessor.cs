using System;
using System.Collections.Generic;
using System.Linq;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor;

namespace TetBet.Server.Services.UpdateOdds
{
    public class SportEventsOddsApiProcessor : ISportEventsOddsApiProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApiInteractor _apiInteractor;

        public SportEventsOddsApiProcessor(
            IUnitOfWork unitOfWork,
            IApiInteractor apiInteractor)
        {
            _unitOfWork = unitOfWork;
            _apiInteractor = apiInteractor;
        }

        public void Process(string sportName)
        {
            List<SportEvent> notStartedSportEvents = _unitOfWork
                .SportEvent
                .Get(sportEvent => sportEvent.Date.CompareTo(DateTime.Now) > 0)
                .ToList();
            
            notStartedSportEvents.ForEach(sportEvent => _apiInteractor.GetOddsForSportEvent(sportEvent));
        }
    }
}