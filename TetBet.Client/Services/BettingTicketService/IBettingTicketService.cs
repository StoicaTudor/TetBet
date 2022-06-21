using TetBet.Core.Dtos.CreationDtos;

namespace TetBet.Client.Services.BettingTicketService
{
    public interface IBettingTicketService
    {
        void AddBetToSessionBettingTicket(UserBetCreationDto userBetCreationDto);

        void SubmitSessionBettingTicket();

        void DeleteSessionBettingTicket();
    }
}