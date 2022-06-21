using System;
using System.Linq;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TetBet.Client.Services;
using TetBet.Client.Services.LoginService;
using TetBet.Client.Services.LoginService.Exceptions;
using TetBet.Client.Services.SessionService;
using TetBet.Core.Dtos;
using Unity;

namespace TetBet.Client.Controllers
{
    [EnableCors("CorsPolicy")]
    [Route("TetBet/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly ILoginService _loginService;

        public LoginController()
        {
            var container = IocConfig.GetConfiguredContainer();
            _loginService = container.Resolve<ILoginService>();
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("signIn")]
        public IActionResult SignIn(LoginDto loginDto)
        {
            try
            {
                long id = _loginService.SignIn(loginDto);
                HttpContext.Session.SetString(ISessionService.UserId, id.ToString());
                return Ok(id);
            }
            catch (LoginUserNotFoundException)
            {
                return NotFound();
            }
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("signUp")]
        public IActionResult SignUp(LoginDto loginDto)
        {
            long id = _loginService.SignUp(loginDto);
            HttpContext.Session.SetString(ISessionService.UserId, id.ToString());
            return Ok(id);
        }

        [EnableCors("CorsPolicy")]
        [HttpPost("getSessionUserId")]
        public IActionResult GetSessionUserId()
        {
            Console.WriteLine(HttpContext.Session.Keys.ToList().Count);
            return Ok(HttpContext.Session.GetString(ISessionService.UserId));
        }
    }
}