using AutoMapper;
using TetBet.Core.Dtos.CreationDtos;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;

namespace TetBet.Client.Application.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public void CreateTransaction(TransactionCreationDto transactionCreationDto)
        {
            var transaction = _mapper.Map<Transaction>(transactionCreationDto);
            _unitOfWork.Transaction.Insert(transaction);
            _unitOfWork.Commit();
        }
    }
}