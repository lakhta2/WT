using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchTogetherApi.Contracts;
using WatchTogetherApplication.Services;
using WatchTogetherCore.Models;

namespace WatchTogetherApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        private readonly IUserService _userService;
        //private const string AuthSchemes = CookieAuthenticationDefaults.AuthenticationScheme + "," + JwtBearerDefaults.AuthenticationScheme;
        
        public AuthenticationController(IUserService userService)
        {
            _userService = userService;
        }
        /*
        [HttpPost("login")]
        public async Task<IResult> Login([FromBody] LoginRequest request)
        {
            var context = HttpContext;
            var token = await _userService.Login(request.Email, request.Password);

            context.Response.Cookies.Append("Tasty-cookies", token);

            return Results.Ok(token);
        } 
        */
        /*
        [Authorize(AuthenticationSchemes = /*AuthSchemes*/ /* CookieAuthenticationDefaults.AuthenticationScheme)] */ /*
        [HttpGet]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            var response = users.Select(b => new UsersResponse(b.Id, b.UserName, b.Description, b.Hours));
            return Ok(response);
        }
        */
       
    }
}
