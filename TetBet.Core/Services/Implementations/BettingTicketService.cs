using AutoMapper;
using TetBet.Core.Dtos.CreationDtos;
using TetBet.Core.Repositories;
using TetBet.Core.Services.Interfaces;
using TetBet.Data.Entities;

namespace TetBet.Core.Services.Implementations
{
    public class BettingTicketService : IBettingTicketService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _bettingTicketMapper;
        private readonly IMapper _userBetMapper;

        public BettingTicketService(IUnitOfWork unitOfWork, IMapper bettingTicketMapper, IMapper userBetMapper)
        {
            _unitOfWork = unitOfWork;
            _bettingTicketMapper = bettingTicketMapper;
            _userBetMapper = userBetMapper;
        }

        public void AddBetToBettingTicket(UserBetCreationDto userBetCreationDto)
        {
            // TODO: add it to SESSION
            throw new System.NotImplementedException();
        }

        public void SubmitBettingTicket(BettingTicketCreationDto bettingTicketCreationDto)
        {
            var bettingTicket = _userBetMapper.Map<BettingTicket>(bettingTicketCreationDto);
            _unitOfWork.BettingTicketRepository.Insert(bettingTicket);
        }
    }
}