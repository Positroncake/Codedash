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
    public ActionResult CheckProblem([FromQuery] Guid id, List<string> vals)
    {
        Problem problem;
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
            return NotFound();
        }

        var blocks = ProblemBlock.ParseProblemString(problem.Chunks!)
            .Where((chunk) => chunk.IsInput).Select((chunk, idx) => chunk.Content);

        // Zip/Select does interleave
        var args = vals.Zip(blocks, (val, block) => new { Val = val, Block = block })
            .SelectMany((pack) => new[] { pack.Val, pack.Block }).ToList();
        
        var matches = TokenMatch(args);
        
        return Ok(matches);
    }

    [NonAction]
    private List<int> TokenMatch(List<string> args)
    {
        args.Prepend("Python/token-match.py");

        var startInfo = new ProcessStartInfo
        {
            FileName = "python3",
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };
        foreach (var a in args) {
            startInfo.ArgumentList.Add(a);
        }

        var proc = new Process
        {
            StartInfo = startInfo
        };
        proc.Start();
        string output = proc.StandardOutput.ReadToEnd();
        proc.WaitForExit();
        return Regex.Split(output, "\r?\n").Select((val, idx) => int.Parse(val)).ToList();
    }
};