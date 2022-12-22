using ApiRest.Business.Interfaces;
using ApiRest.Data.VO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {

        private ILoginBusiness _loginBusiness;

        public AuthController (ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] AuthUserVO user)
        {
            if (user == null)
                return BadRequest("Invalid client Request");

            var token = _loginBusiness.ValidateCredentials(user);

            if (token == null)
                return Unauthorized();

            return Ok();
        }
    }
}
