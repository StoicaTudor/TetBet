namespace TetBet.Client.Services.SessionService
{
    public interface ISessionService
    {
        const string UserId = "UserId";
        const string BettingTicketId = "SessionBettingTicketId";
        long GetSessionUserId();

        long GetSessionBettingTicketId();
    }
}