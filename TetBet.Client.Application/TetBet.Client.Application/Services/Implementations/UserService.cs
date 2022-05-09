using System;
using AutoMapper;
using TetBet.Client.Application.Services.Interfaces;
using TetBet.Core.Dtos;
using TetBet.Core.Dtos.GetDtos;
using TetBet.Infrastructure.Persistence.Repositories.Interfaces;

namespace TetBet.Core.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _userMapper;

        public UserService(IUnitOfWork unitOfWork, IMapper userMapper)
        {
            _unitOfWork = unitOfWork;
            _userMapper = userMapper;
        }

        public UserGetDto GetUserById(long userId)
        {
            // TODO: custom exceptions/message in exception
            var user = _unitOfWork.UserRepository.GetById(userId) ?? throw new Exception();
            return _userMapper.Map<UserGetDto>(user);
        }
    }
}