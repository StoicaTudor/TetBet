using TetBet.Core.Dtos.CreationDtos;

namespace TetBet.Client.Application.Services.Interfaces
{
    public interface IBettingTicketService
    {
        void AddBetToBettingTicket(UserBetCreationDto userBetCreationDto);
        void SubmitBettingTicket(BettingTicketCreationDto bettingTicketCreationDto);
    }
}