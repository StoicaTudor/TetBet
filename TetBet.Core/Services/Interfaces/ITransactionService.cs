using TetBet.Core.Dtos.CreationDtos;

namespace TetBet.Core.Services.Interfaces
{
    public interface ITransactionService
    {
        void CreateTransaction(TransactionCreationDto transactionCreationDto);
    }
}