using AutoMapper;
using TetBet.Core.Dtos.CreationDtos;
using TetBet.Infrastructure.Entities;
using TetBet.Infrastructure.Persistence.Repositories.UnitOfWork;

namespace TetBet.Client.Services.TransactionService
{
    public class TransactionService : ITransactionService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _transactionMapper;

        public TransactionService(IUnitOfWork unitOfWork, IMapper transactionMapper)
        {
            _unitOfWork = unitOfWork;
            _transactionMapper = transactionMapper;
        }

        public void CreateTransaction(TransactionCreationDto transactionCreationDto)
        {
            var transaction = _transactionMapper.Map<Transaction>(transactionCreationDto);
            _unitOfWork.Transaction.Insert(transaction);
        }
    }
}