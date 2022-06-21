using System.Collections.Generic;
using AutoMapper;
using TetBet.Core.Dtos.GetDtos;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;

namespace TetBet.Client.Services.SportEventService
{
    public class SportEventService : ISportEventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _sportEventMapper;

        public SportEventService(IUnitOfWork unitOfWork, IMapper sportEventMapper)
        {
            _unitOfWork = unitOfWork;
            _sportEventMapper = sportEventMapper;
        }

        public IEnumerable<SportEventGetDto> GetNearFutureActiveSportEvents(int nrDays)
        {
            // TODO: call the get properly
            var sportEvents = _unitOfWork.SportEvent.Get();
            return _sportEventMapper.Map<IEnumerable<SportEventGetDto>>(sportEvents);
        }

        public SportEventGetDto GetSportEventById(long id)
        {
            var sportEvent = _unitOfWork.SportEvent.GetById(id);
            return _sportEventMapper.Map<SportEventGetDto>(sportEvent);
        }
    }
}