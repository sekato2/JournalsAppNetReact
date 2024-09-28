using Journals.Application.Journals;
using Journals.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace JournalsAppNetReact.Server.Controllers;

[ApiController]
[Route("api/journals")]
public class JournalsController(IJournalsService journalsServices) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var journals = await journalsServices.GetAll();
        return Ok(journals);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById([FromRoute] int id)
    {
        var journal = await journalsServices.GetById(id);
        if (journal == null)
            return NotFound();
        return Ok(journal);
    }

    [HttpPost]
    public async Task<IActionResult> CreateJournal([FromBody] Journal journal)
    {
        int id = await journalsServices.Create(journal);
        return CreatedAtAction(nameof(GetById), new { id }, null);
    }
}
