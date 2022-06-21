using TetBet.Core.Dtos.CreationDtos;

namespace TetBet.Client.Services.TransactionService
{
    public interface ITransactionService
    {
        void CreateTransaction(TransactionCreationDto transactionCreationDto);
    }
}