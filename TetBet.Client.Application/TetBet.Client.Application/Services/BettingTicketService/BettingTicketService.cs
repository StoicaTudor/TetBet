using System.Linq;
using AutoMapper;
using TetBet.Client.Application.Services.BettingTicketService.Exceptions;
using TetBet.Client.Application.Services.SessionService;
using TetBet.Core.Dtos.CreationDtos;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;

namespace TetBet.Client.Application.Services.BettingTicketService
{
    public class BettingTicketService : IBettingTicketService
    {
        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _bettingTicketMapper;
        private readonly IMapper _userBetMapper;
        private readonly IMapper _userMapper;

        private readonly ISessionService _sessionService;
        private readonly Core.BusinessRules.BettingTicketService.IBettingTicketService _bettingTicketService;

        public BettingTicketService(
            IUnitOfWork unitOfWork,
            IMapper bettingTicketMapper,
            IMapper userBetMapper,
            ISessionService session,
            Core.BusinessRules.BettingTicketService.IBettingTicketService bettingTicketService,
            IMapper userMapper)
        {
            _unitOfWork = unitOfWork;
            _bettingTicketMapper = bettingTicketMapper;
            _userBetMapper = userBetMapper;
            _sessionService = session;
            _bettingTicketService = bettingTicketService;
            _userMapper = userMapper;
        }

        public void AddBetToSessionBettingTicket(UserBetCreationDto userBetCreationDto)
        {
            UserBet userBet = _userBetMapper.Map<UserBet>(userBetCreationDto);

            BettingTicket bettingTicket;

            try
            {
                long sessionBettingTicketId = _sessionService.GetSessionBettingTicketId();

                bettingTicket = _unitOfWork
                    .BettingTicket
                    .GetById(sessionBettingTicketId);
            }
            catch (BettingTicketNotFoundException)
            {
                User sessionUser = _unitOfWork
                    .User
                    .GetById(_sessionService.GetSessionUserId());

                bettingTicket = _bettingTicketService.GetEmptyBettingTicket(sessionUser.AccountDetails);

                _unitOfWork
                    .BettingTicket
                    .Insert(bettingTicket);
            }

            bettingTicket.UserBets = bettingTicket
                .UserBets
                .Append(userBet);

            _unitOfWork.BettingTicket.Update(bettingTicket);

            _unitOfWork.Commit();
        }

        public void SubmitSessionBettingTicket()
        {
            long bettingTicketId = _sessionService.GetSessionBettingTicketId();
            BettingTicket bettingTicket = _unitOfWork
                .BettingTicket
                .GetById(bettingTicketId);

            bettingTicket.BettingTicketStatus = BettingTicketStatus.Pending;

            _unitOfWork.BettingTicket.Insert(bettingTicket);

            _unitOfWork.Commit();
        }

        public void DeleteSessionBettingTicket()
        {
            long sessionBettingTicketId = _sessionService.GetSessionBettingTicketId();

            _unitOfWork
                .BettingTicket
                .Delete(sessionBettingTicketId);

            _unitOfWork.Commit();
        }
    }
}