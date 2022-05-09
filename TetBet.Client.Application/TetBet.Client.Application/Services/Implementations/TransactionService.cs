using AutoMapper;
using TetBet.Client.Application.Services.Interfaces;
using TetBet.Core.Dtos.CreationDtos;
using TetBet.Core.Repositories;
using TetBet.Infrastructure.Entities;

namespace TetBet.Client.Application.Services.Implementations
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
            _unitOfWork.TransactionRepository.Insert(transaction);
        }
    }
}