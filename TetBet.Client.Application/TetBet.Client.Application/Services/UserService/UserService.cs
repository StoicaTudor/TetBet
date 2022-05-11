using System;
using AutoMapper;
using TetBet.Client.Application.Services.SessionService;
using TetBet.Client.Application.Services.UserService.Exceptions;
using TetBet.Core.Dtos.GetDtos;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.Interfaces;

namespace TetBet.Client.Application.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _userMapper;
        private readonly ISessionService _session;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper userMapper,
            ISessionService session)
        {
            _unitOfWork = unitOfWork;
            _userMapper = userMapper;
            _session = session;
        }

        public UserGetDto GetUserById(long userId)
        {
            User user = _unitOfWork
                            .UserRepository
                            .GetById(userId)
                        ?? throw new UserNotFoundException();

            return _userMapper.Map<UserGetDto>(user);
        }

        public UserGetDto GetSessionUser()
        {
            User user = _unitOfWork
                            .UserRepository
                            .GetById(_session.GetSessionUserId())
                        ?? throw new UserNotFoundException();

            return _userMapper.Map<UserGetDto>(user);
        }
    }
}