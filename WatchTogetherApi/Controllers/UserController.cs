using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchTogetherApi.Contracts;
using WatchTogetherApplication.Services;
using Microsoft.Extensions.Logging;
using WatchTogetherCore.Models;

namespace WatchTogetherApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;
        public UserController(ILogger<UserController> logger, IUserService userService)
        {
            _userService = userService;
            _logger = logger;
        }

        /*
        [HttpGet("~/api/")]
        public async Task<ActionResult<List<UsersResponse>>> GetUsers()
        {
            var users = await _userService.GetUsers();
            var response = users.Select(b => new UsersResponse(b.Id, b.UserName, b.Description, b.Hours));
            return Ok(response);
        }
        

        [HttpPatch("~/api/login")]
        public async Task<IResult> Login([FromBody] TLoginRequest request)
        {
            var context = HttpContext;
            var token = await _userService.Login(request.Email, request.Password);

            if (token == null)
                return Results.Unauthorized();

            context.Response.Cookies.Append("Tasty-cookies", token);

            return Results.Ok(token);
        }
        
        
        [HttpPost("~/api/register/v1")]
        public async Task<IResult> CreateUser([FromBody] UserRegisterRequest request)
        { 
            _logger.LogInformation("RequestBefore"+request.Username+request.Email+request.Password);

            await _userService.Register(request.Username, request.Email, request.Password);

            return Results.Ok();
        }
        

        [HttpPost("~/api/register/v2")]
        public async Task<ActionResult<Guid>> CreateUser([FromBody] UserRequest request)
        {
                var (user, error) = WatchTogetherCore.Models.User.Create(Guid.NewGuid(), request.Username,
                    request.Description,
                    request.Hours);

                if (!string.IsNullOrEmpty(error))
                {
                    return BadRequest(error);
                }

                var bookId = await _userService.CreateUser(user);

                return CreatedAtAction("Post", bookId);
            
        }


        [HttpPut("{id:guid}")]
        public async Task<ActionResult<Guid>> UpdateUser(Guid id, [FromBody] UserRequest request)
        {
            var exist = await _userService.IsUserExists(id);
            if (!exist)
                return NotFound();

            var user_id = await _userService.UpdateUser(id, request.Username, request.Description, (int)request.Hours);

            //return Ok(user_id);
            return NoContent();
        }


        [HttpDelete("{id:guid}")]
        public async Task<ActionResult<Guid>> DeleteUser(Guid id)
        {
            var exist = await _userService.IsUserExists(id);
            if (!exist)
                return NotFound();

            await _userService.DeleteUser(id);

            return NoContent();
        }
        */
    }
}
