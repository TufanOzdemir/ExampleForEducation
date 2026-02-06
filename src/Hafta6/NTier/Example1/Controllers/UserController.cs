using Example1.Abstraction;
using Example1.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Example1.Controllers;
[Route("api/[controller]")]
[ApiController]
public class UserController(IUserService _userService) : ControllerBase
{
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
