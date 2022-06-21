using AutoMapper;
using TetBet.Client.Services.UserService.Exceptions;
using TetBet.Core.Dtos.GetDtos;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;

namespace TetBet.Client.Services.UserService
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _userMapper;

        public UserService(
            IUnitOfWork unitOfWork,
            IMapper userMapper)
        {
            _unitOfWork = unitOfWork;
            _userMapper = userMapper;
        }

        public UserGetDto GetUserById(long userId)
        {
            User user = _unitOfWork
                            .User
                            .GetById(userId)
                        ?? throw new UserNotFoundException();

            return _userMapper.Map<UserGetDto>(user);
        }
    }
}