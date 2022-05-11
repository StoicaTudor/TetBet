using TetBet.Core.Dtos.CreationDtos;

namespace TetBet.Client.Application.Services.TransactionService
{
    public interface ITransactionService
    {
        void CreateTransaction(TransactionCreationDto transactionCreationDto);
    }
}