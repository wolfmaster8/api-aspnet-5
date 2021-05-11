using Microsoft.AspNetCore.Mvc;
using RestApi.Business;
using RestApi.Data.VO;

namespace RestApi.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly ILoginBusiness _loginBusiness;

        public AuthController(ILoginBusiness loginBusiness)
        {
            _loginBusiness = loginBusiness;
        }

        [HttpPost]
        [Route("login")]
        public IActionResult Login([FromBody] UserVO user)
        {
            if (user == null) return BadRequest("Invalid Request");

            var token = _loginBusiness.ValidateCredentials(user);
            if (token == null) return Unauthorized();
            
            return Ok(token);
        }
    }
}