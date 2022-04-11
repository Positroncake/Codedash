using codedash.Shared;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Text.Json;
using codedash.Server.Data;

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

    [HttpGet("Get/{id}")]
    public ActionResult GetProblemById(string id)
    {
        Problem? problem = FindProblem(id);
        if (problem is null) return NotFound();
        return Ok(problem);
    }

    [HttpGet("List")]
    public ActionResult GetFullList()
    {
        List<Problem> result = _context.Problem!.ToList();
        return Ok(result);
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

        IEnumerable<string?> blocks = ProblemBlock.ParseProblemString(problem.Chunks!)
            .Where((chunk) => chunk.IsInput).Select((chunk, _) => chunk.Content);

        // Zip/Select does interleave
        List<string?> args = vals.Zip(blocks, (val, block) => new { Val = val, Block = block })
            .SelectMany((pack) => new[] { pack.Val, pack.Block }).ToList();
        
        string matches = TokenMatch(args);

        var res = matches.Split(new[] {"\n", "\r\n", "\r"}, StringSplitOptions.RemoveEmptyEntries)
            .Select((str, _) => int.Parse(str)).ToList();
        
        Console.Write("Python list: ");
        foreach (var i in res)
            Console.Write($"{i} ");
        Console.WriteLine();
        
        return Ok(res);
    }
    
    [NonAction]
    private string TokenMatch(List<string?> args)
    {
        args.Insert(0, "Python/token-match.py");

        var startInfo = new ProcessStartInfo
        {
            FileName = "python3",
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };
        foreach (string? a in args) {
            startInfo.ArgumentList.Add(a!);
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
    
    [HttpPost("Submit")]
    public ActionResult AddCustomSubmission(Problem problem)
    {
        AddToDb(problem);
        return Ok(problem.Id);
    }

    [NonAction]
    public async void AddToDb(Problem problem)
    {
        _context.Add(problem);
        await _context.SaveChangesAsync();
    }

    [HttpGet("Campaign/{level}")]
    public ActionResult GetCampaignLevel(int level)
    {
        string jsonText = System.IO.File.ReadAllText("Files/campaign-levels.json");
        var levels = JsonSerializer.Deserialize<List<string>>(jsonText)!;

        if (level >= levels.Count)
        {
            return BadRequest("Level out of bounds");
        }

        return Ok(levels[level]);
    }
};