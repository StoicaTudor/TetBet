using Microsoft.AspNetCore.Http;
using TetBet.Client.Application.Services.BettingTicketService.Exceptions;
using TetBet.Client.Application.Services.SessionService.Exceptions;
using TetBet.Client.Application.Services.UserService;

namespace TetBet.Client.Application.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly IUserService _userService;

        public SessionService(IUserService userService)
        {
            _userService = userService;
        }

        public long GetSessionUserId()
        {
            CheckSession();
            string userId = Session.GetString(ISessionService.UserId);
            
            if (userId == null)
            {
                throw new SessionExpiredException();
            }

            return long.Parse(userId);
        }

        public long GetSessionBettingTicketId()
        {
            CheckSession();
            string bettingTicketId = Session.GetString(ISessionService.BettingTicketId);
            
            if (bettingTicketId == null)
            {
                throw new BettingTicketNotFoundException();
            }

            return long.Parse(bettingTicketId);
        }

        private void CheckSession()
        {
            if (!Session.IsAvailable)
            {
                throw new SessionExpiredException();
            }
        }

        public ISession Session { get; set; }
    }
}