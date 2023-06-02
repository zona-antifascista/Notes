using Microsoft.AspNetCore.Mvc;
using Notes.Api.Domain;

namespace Notes.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class NoteController : ControllerBase
{
    private readonly NoteRepository _repo;

    public NoteController(NoteRepository repo)
    {
        _repo = repo;
    }

    [HttpGet]
    public async Task<ActionResult> GetAllNotes()
    {
        return Ok(await _repo.GetAllAsync());
    }
}
