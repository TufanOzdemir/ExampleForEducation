using ProductService.Application.DTOs;
using ProductService.Application.UseCases.Users.GetUserById;
using ProductService.Application.UseCases.Users.Login;
using ProductService.Application.Abstraction;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ProductService.Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IMediator mediator, IUserService userService) : ControllerBase
{
    [HttpGet("GetAll")]
    [Authorize(Roles = "GetAll_User")]
    public IActionResult GetAllUsers()
    {
        var users = userService.GetAll();
        return Ok(users);
    }

    [HttpGet("Test")]
    [Authorize(Roles = "GetById_User")]
    public async Task<IActionResult> GetUserById(int id)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id));
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
