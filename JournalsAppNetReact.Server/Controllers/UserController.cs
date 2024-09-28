using Journals.Application.Users;
using Journals.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JournalsAppNetReact.Server.Controllers;

[ApiController]
[Route("api/users")]
public class UserController(IUsersService usersServices) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var users = await usersServices.GetAll();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var user = await usersServices.GetById(id);
        if (user == null)
            return NotFound();
        return Ok(user);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] User user)
    {
        int id = await usersServices.Create(user);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
