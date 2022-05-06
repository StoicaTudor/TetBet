using System;
using System.Collections.Generic;
using TetBet.Core.Entities;

namespace TetBet.Core.Dtos.User
{
    public class UserGetDto
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public AccountDetailsGetDto AccountDetails { get; set; }
    }
}