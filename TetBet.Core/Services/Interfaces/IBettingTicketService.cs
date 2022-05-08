using TetBet.Core.Dtos.CreationDtos;

namespace TetBet.Core.Services.Interfaces
{
    public interface IBettingTicketService
    {
        void AddBetToBettingTicket(UserBetCreationDto userBetCreationDto);
        void SubmitBettingTicket(BettingTicketCreationDto bettingTicketCreationDto);
    }
}