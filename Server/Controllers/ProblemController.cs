using codedash.Shared;
using Microsoft.AspNetCore.Mvc;

namespace codedash.Server.Controllers;

[ApiController]
[Route("ProblemApi")]
public class ProblemController : ControllerBase
{
    private readonly ProblemDbContext _context;

    public ProblemController(ProblemDbContext context)
    {
        _context = context;
    }
    
    [HttpGet("Get")]
    public ActionResult GetProblemById(Guid id)
    {
        Problem? problem = FindProblem(id);
        if (problem is null) return NotFound();
        return Ok(problem);
    }

    [NonAction]
    private Problem? FindProblem(Guid id)
    {
        return _context.Problem!.FirstOrDefault(p => p.Id == id, null);
    }

    [HttpPost("Verify")]
    public ActionResult CheckProblem(Guid id)
    {
        return new StatusCodeResult(StatusCodes.Status501NotImplemented);
    }
};