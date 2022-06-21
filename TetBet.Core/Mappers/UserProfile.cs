using AutoMapper;
using TetBet.Core.Dtos.GetDtos;
using TetBet.Infrastructure.Entities;

namespace TetBet.Core.Mappers
{
    public class UserProfile : Profile
    {
        // private readonly IMapper _accountDetailsMapper;

        public UserProfile() // public UserProfile(IMapper accountDetailsMapper)
        {
            // _accountDetailsMapper = accountDetailsMapper;

            CreateMap<UserGetDto, User>();
            // .ForMember(user => user.AccountDetails,
            //     options
            //         => options.MapFrom(userGetDto => userGetDto.AccountDetails));
        }
    }
}