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

    [NonAction]
    private Problem? FindProblem(Guid id)
    {
        return _context.Problem!.FirstOrDefault(p => p.Id == id, null);
    }
    
    [HttpGet("Get")]
    public ActionResult GetProblemByID(Guid id)
    {
        Problem? problem = FindProblem(id);
        if (problem is null)
        {
            return NotFound();
        }
        else
        {
            return Ok(problem);
        }
    }
};