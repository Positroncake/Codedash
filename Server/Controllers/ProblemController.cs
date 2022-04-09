using codedash.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.RegularExpressions;

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
    public ActionResult GetProblemById(string id)
    {
        Problem? problem = FindProblem(id);
        if (problem is null) return NotFound();
        return Ok(problem);
    }

    [NonAction]
    private Problem? FindProblem(string id)
    {
        return _context.Problem!.ToList().FirstOrDefault(problem => problem.Id!.Equals(id));
    }

    [HttpPost("Verify/{id}")]
    public ActionResult CheckProblem([FromRoute] string id, List<string> vals)
    {
        Problem problem;
        id = id.ToLowerInvariant();
        try
        {
            problem = ((Func<Problem>)(() =>
            {
                Problem? res = FindProblem(id);
                if (res is null) throw new InvalidOperationException();
                return res;
            }))();
        }
        catch (InvalidOperationException)
        {
            return NotFound($"Could not find item with ID {id} in database");
        }

        var blocks = ProblemBlock.ParseProblemString(problem.Chunks!)
            .Where((chunk) => chunk.IsInput).Select((chunk, idx) => chunk.Content);

        // Zip/Select does interleave
        var args = vals.Zip(blocks, (val, block) => new { Val = val, Block = block })
            .SelectMany((pack) => new[] { pack.Val, pack.Block }).ToList();
        
        // var matches = TokenMatch(args);
        string matches = TokenMatch(args);
        
        return Ok(matches);
    }

    [NonAction]
    private string TokenMatch(List<string> args)
    {
        args.Insert(0, "Python/token-match.py");

        var startInfo = new ProcessStartInfo
        {
            FileName = "python3",
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };
        foreach (var a in args) {
            startInfo.ArgumentList.Add(a);
        }

        var process = new Process
        {
            StartInfo = startInfo
        };
        process.Start();
        string output = process.StandardOutput.ReadToEnd();
        process.WaitForExit();
        return output;
        // return Regex.Split(output, "\r?\n").Select((val, idx) => int.Parse(val)).ToList();
    }
};