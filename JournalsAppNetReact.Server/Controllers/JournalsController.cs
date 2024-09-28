using Microsoft.AspNetCore.Mvc;

namespace JournalsAppNetReact.Server.Controllers;

[ApiController]
[Route("api/journals")]
public class JournalsController : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        return Ok();
    }
}
