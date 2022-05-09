using TetBet.Core.Dtos.CreationDtos;

namespace TetBet.Client.Application.Services.Interfaces
{
    public interface ITransactionService
    {
        void CreateTransaction(TransactionCreationDto transactionCreationDto);
    }
}