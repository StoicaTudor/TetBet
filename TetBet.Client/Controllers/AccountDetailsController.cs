using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using TetBet.Client.Services.SessionService;
using TetBet.Client.Services.TransactionService;
using TetBet.Core.Dtos.CreationDtos;
using Unity;

namespace TetBet.Client.Controllers
{
    [Route("TetBet/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        private readonly ISessionService _sessionService;
        private readonly ITransactionService _transactionService;

        public AccountDetailsController()
        {
            var container = IocConfig.GetConfiguredContainer();
            _sessionService = container.Resolve<ISessionService>();
            _transactionService = container.Resolve<ITransactionService>();
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("depositMoney")]
        public IActionResult DepositMoney(TransactionCreationDto transactionCreationDto)
        {
            transactionCreationDto.Currency = "RON";

            if (transactionCreationDto.Sum <= 0)
                return Forbid();

            _transactionService.CreateTransaction(transactionCreationDto);
            return Ok("asdas");
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("withdrawMoney")]
        public IActionResult WithdrawMoney(TransactionCreationDto transactionCreationDto)
        {
            transactionCreationDto.Currency = "RON";

            if (transactionCreationDto.Sum > 0)
                transactionCreationDto.Sum *= -1;

            _transactionService.CreateTransaction(transactionCreationDto);
            return Ok("asdas");
        }
    }
}