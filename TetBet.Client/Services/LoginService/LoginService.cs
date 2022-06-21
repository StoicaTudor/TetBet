using System;
using System.Linq;
using TetBet.Client.Services.UserService.Exceptions;
using TetBet.Core.Dtos;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;

namespace TetBet.Client.Services.LoginService
{
    public class LoginService : ILoginService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LoginService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public long SignIn(LoginDto loginDto)
        {
            string email = loginDto.Email;
            string password = loginDto.Password;

            var searchResult = _unitOfWork
                .User
                .Get(user => user.Email.Equals(email) && user.Password.Equals(password))
                .ToList();

            if (searchResult.Any())
                return searchResult.First().Id;

            throw new UserNotFoundException();
        }

        public long SignUp(LoginDto loginDto)
        {
            string email = loginDto.Email;
            string password = loginDto.Password;

            User user = new User
            {
                Email = email,
                Password = password,
                AccountDetails = new AccountDetails
                {
                    AccountBalance = 0,
                    DateRegistered = DateTime.Now
                },
            };

            _unitOfWork.User.Insert(user);
            _unitOfWork.Commit();

            return user.Id;
        }
    }
}