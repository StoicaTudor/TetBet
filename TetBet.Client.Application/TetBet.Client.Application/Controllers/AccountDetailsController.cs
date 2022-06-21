using Microsoft.AspNetCore.Mvc;

namespace TetBet.Client.Application.Controllers
{
    [Route("TetBet/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        // [HttpGet("{value}", Name = "depositMoney")]
        [HttpGet("depositMoney")]
        public IActionResult DepositMoney()
        {
            return Ok("asdas");
        }
    }
}