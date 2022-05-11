using Microsoft.AspNetCore.Http;

namespace TetBet.Client.Application.Services.SessionService
{
    public interface ISessionService
    {
        const string UserId = "UserId";
        const string BettingTicketId = "SessionBettingTicketId";
        public ISession Session { get; set; }
        long GetSessionUserId();

        long GetSessionBettingTicketId();
    }
}