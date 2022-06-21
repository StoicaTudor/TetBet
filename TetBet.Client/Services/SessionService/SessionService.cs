using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TetBet.Client.Application.Services.BettingTicketService.Exceptions;
using TetBet.Client.Services.SessionService.Exceptions;
using TetBet.Client.Services.UserService;
using TetBet.Infrastructure.Entities;

namespace TetBet.Client.Services.SessionService
{
    public class SessionService : ISessionService
    {
        private readonly IUserService _userService;
        private readonly ISession _session;

        public SessionService(IUserService userService, ISession session)
        {
            _userService = userService;
            _session = session;
        }

        public void SetUserInSession(User user)
        {
            // System.Web.HttpContext.Current.Session
            CheckSession();
            _session.SetString(ISessionService.UserId, user.Id.ToString());
        }

        public long GetSessionUserId()
        {
            CheckSession();
            string userId = _session.GetString(ISessionService.UserId);

            if (userId == null)
                throw new SessionExpiredException();

            return long.Parse(userId);
        }

        public long GetSessionBettingTicketId()
        {
            CheckSession();
            string bettingTicketId = _session.GetString(ISessionService.BettingTicketId);

            if (bettingTicketId == null)
            {
                throw new BettingTicketNotFoundException();
            }

            return long.Parse(bettingTicketId);
        }

        private void CheckSession()
        {
            if (!_session.IsAvailable)
                throw new SessionExpiredException();
        }
    }
}