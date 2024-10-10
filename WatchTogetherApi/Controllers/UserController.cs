using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchTogetherApi.Contracts;
using WatchTogetherApplication.Services;
using Microsoft.Extensions.Logging;
using WatchTogetherCore.Models;
using Microsoft.AspNetCore.Identity;
using WatchTogetherApi.Extensions;
using Azure.Core;

namespace WatchTogetherApi.Controllers
{
    [ApiController]
    [Authorize(AuthenticationSchemes = "Identity.Application")]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IIndexService _indexService;
        private readonly ILogger<UserController> _logger;
        private readonly HateoasGenerator _HateoasGenerator;
        public UserController(ILogger<UserController> logger, IUserService userService, IIndexService indexService, HateoasGenerator hateoasGenerator)
        {
            _userService = userService;
            _logger = logger;
            _indexService = indexService;
            _HateoasGenerator = hateoasGenerator;
        }
        [HttpGet("~/test")]
        public async Task<ActionResult<List<User>>> GetUsers()
        {
            var users = await _indexService.GetAllUsersTestAsync();
            var response = users.Select(b => new UsersResponse(b.Id, b.UserName, b.Description, b.Hours));
            return Ok(response);
        }
        [HttpGet("~/{id:guid}")]
        public async Task<ActionResult<User>> GetUserById(Guid id)
        {
            _logger.LogInformation("RequestBefore");
            _HateoasGenerator.CreateLinksDictionary();
            var user = await _indexService.GetUserByIdAsync(id);
            //var test = await _indexService.
            var response = new UsersResponse(id, user.UserName, user.Description, user.Hours);
            return Ok(response);
        }
    }
}
