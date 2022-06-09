using System;
using System.Collections.Generic;
using System.Linq;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;
using TetBet.Server.Infrastructure.Services.RapidApi.ApiInteractor;
using TetBet.Server.Services.BetWinnerProcessor;

namespace TetBet.Server.Services.FetchNewSportEvents
{
    public class SportEventsApiProcessor : ISportEventsApiProcessor
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IApiInteractor _apiInteractor;
        private readonly IBetWinnerProcessor _betWinnerProcessor;

        public SportEventsApiProcessor(
            IUnitOfWork unitOfWork,
            IApiInteractor apiInteractor,
            IBetWinnerProcessor betWinnerProcessor)
        {
            _unitOfWork = unitOfWork;
            _apiInteractor = apiInteractor;
            _betWinnerProcessor = betWinnerProcessor;
        }

        public void Process(string sportName)
        {
            List<Competition> inProgressCompetitions = GetInProgressCompetitions();

            if (!inProgressCompetitions.Any())
                throw new FetchedCollectionIsEmptyException();

            List<long> inProgressCompetitionsIds = GetInProgressCompetitionsIds(inProgressCompetitions);
            int season = GetSeason(inProgressCompetitions);

            inProgressCompetitionsIds.ForEach(inProgressCompetitionsId =>
                {
                    List<SportEvent> apiSportEvents =
                        _apiInteractor
                            .GetSportEvents(inProgressCompetitionsId, season)
                            .ToList();

                    apiSportEvents.ForEach(ProcessSportEvent);
                }
            );
            // _unitOfWork.Commit();
        }

        private void ProcessSportEvent(SportEvent apiSportEvent)
        {
            SportEvent dbIdentifiedSportEvent = _unitOfWork
                .SportEvent
                .Get(sportEvent => sportEvent.RapidApiId == apiSportEvent.RapidApiId)
                .FirstOrDefault();

            if (dbIdentifiedSportEvent == null)
            {
                // TODO: this is not a good practice, but I do not know how to deal with it (EF insert nested objects)
                apiSportEvent.CompetitionId = apiSportEvent.Competition.Id;
                apiSportEvent.Competition = null;

                _unitOfWork.SportEvent.Insert(apiSportEvent);
            }
            else
                ProcessSportEventWhenIdentifiedSportEventIsNotNull(apiSportEvent, dbIdentifiedSportEvent);

            _unitOfWork.Commit();
        }

        private void ProcessSportEventWhenIdentifiedSportEventIsNotNull(
            SportEvent apiSportEvent,
            SportEvent identifiedSportEvent)
        {
            switch (identifiedSportEvent.Status)
            {
                case SportEventStatus.Ended:
                    // we do not process anything, SportEvent is ENDED
                    break;

                case SportEventStatus.InProgress:

                    if (apiSportEvent.Status == SportEventStatus.Ended)
                        UpdateEndedSportEvent(apiSportEvent);

                    break;

                case SportEventStatus.NotStarted:

                    if (apiSportEvent.Status == SportEventStatus.Ended)
                        UpdateEndedSportEvent(identifiedSportEvent);
                    else if (apiSportEvent.Status == SportEventStatus.InProgress)
                        UpdateInProgressSportEvent(identifiedSportEvent);

                    break;

                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void UpdateInProgressSportEvent(SportEvent sportEvent)
        {
            sportEvent.Status = SportEventStatus.InProgress;
            _unitOfWork.SportEvent.Update(sportEvent);
        }

        private void UpdateEndedSportEvent(SportEvent sportEvent)
        {
            sportEvent.Status = SportEventStatus.Ended;
            _unitOfWork.SportEvent.Update(sportEvent);

            List<UserBet> userBetsOnSportEvent = _unitOfWork
                .UserBet
                .Get(userBet =>
                    userBet
                        .SportEventBet
                        .SportEvent
                        .Id == sportEvent.Id)
                .ToList();

            userBetsOnSportEvent.ForEach(userBet =>
            {
                if (_betWinnerProcessor.IsBetWon(userBet))
                    userBet.UserBetStatus = UserBetStatus.Winner;

                userBet.UserBetStatus = UserBetStatus.Canceled;
            });
        }

        private int GetSeason(List<Competition> inProgressCompetitions)
            => inProgressCompetitions
                .First()
                .Season;

        private List<long> GetInProgressCompetitionsIds(List<Competition> inProgressCompetitions)
            => inProgressCompetitions
                .Select(competition => competition.RapidApiId)
                .ToList();

        private List<Competition> GetInProgressCompetitions()
            => _unitOfWork
                .Competition
                .Get(competition => competition.CompetitionStatus == CompetitionStatus.InProgress)
                .ToList();
    }
}