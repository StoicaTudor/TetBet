using AutoMapper;
using TetBet.Core.Dtos.CreationDtos;
using TetBet.Infrastructure.Entities;

namespace TetBet.Core.Mappers
{
    public class TransactionProfile : Profile
    {
        public TransactionProfile()
        {
            CreateMap<TransactionCreationDto, Transaction>();
        }
    }
}