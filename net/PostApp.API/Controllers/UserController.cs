using Microsoft.AspNetCore.Mvc;
using PostApp.Application.Users.Commands.VerifyPasswordHash;
using PostApp.Application.Users.Queries.GetUserByNamePattern;
using PostApp.Application.Users.Queries.GetUserByUsername;

namespace PostApp.API.Controllers;

public class UserController : BaseController
{
    [HttpGet("{username}")]
    public async Task<IActionResult> GetUserByUsername(string username)
    {
        return new OkObjectResult(await Mediator.Send(new GetUserByUsernameQuery(username)));
    }

    [HttpGet("pattern")]
    public async Task<IActionResult> GetTopUsersMatchingNameOrUsernamePattern([FromQuery] string pattern)
    {
        return new OkObjectResult(await Mediator.Send(new GetUserByNamePatternQuery(pattern)));
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] RegisterUserCommand registerUserCommand)
    {
        return new OkObjectResult(await Mediator.Send(registerUserCommand));
    }
}