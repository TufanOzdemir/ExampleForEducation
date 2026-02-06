using Example1.Abstraction;
using Microsoft.AspNetCore.Mvc;

namespace Example1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService service)
    {
        _userService = service;
    }

    [HttpGet("GetAll")]
    public IActionResult GetAllUsers()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }

    [HttpGet("Test")]
    public IActionResult GetUserById(int id)
    {
        var user = _userService.GetById(id);
        if (user == null)
        {
            return NotFound();
        }
        return Ok(user);
    }
}
