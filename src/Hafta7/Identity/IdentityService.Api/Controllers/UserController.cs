using IdentityService.Application.DTOs;
using IdentityService.Application.UseCases.Users.GetUserById;
using IdentityService.Application.UseCases.Users.GetUsers;
using IdentityService.Application.UseCases.Users.Login;
using IdentityService.Application.UseCases.Users.Register;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IdentityService.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IMediator mediator) : ControllerBase
{
    [HttpGet("GetAll")]
    [Authorize(Roles = "GetAll_User")]
    public async Task<IActionResult> GetAllUsers(CancellationToken cancellationToken)
    {
        var users = await mediator.Send(new GetUsersQuery(), cancellationToken);
        return Ok(users);
    }

    [HttpGet("Test")]
    [Authorize(Roles = "GetById_User")]
    public async Task<IActionResult> GetUserById(int id, CancellationToken cancellationToken)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id), cancellationToken);
        return Ok(user);
    }

    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest command, CancellationToken cancellationToken)
    {
        var token = await mediator.Send(new LoginCommand(command.email, command.Password), cancellationToken);
        return Ok(token);
    }

    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest command, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new RegisterCommand(command), cancellationToken);
        return Ok(result);
    }
}
