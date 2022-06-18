using Microsoft.AspNetCore.Mvc;

namespace TetBet.Client.Application.Controllers
{
    [Microsoft.AspNetCore.Mvc.Route("TetBet/[controller]")]
    [ApiController]
    public class AccountDetailsController : ControllerBase
    {
        [System.Web.Http.HttpGet]
        [System.Web.Http.Route("{userId}", Name = "GetUserById")]
        public ActionResult<string> GetUserById(int userId)
        {
            return Ok("aa");
        }
    }
}