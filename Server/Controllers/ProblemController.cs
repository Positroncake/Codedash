using System.Diagnostics;
using System.Text.Json;
using Codedash.Server.Data;
using Codedash.Shared;
using Microsoft.AspNetCore.Mvc;

namespace Codedash.Server.Controllers;

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
    public ActionResult GetProblemById(String id)
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
    private Problem? FindProblem(String id)
    {
        return _context.Problem!.ToList().FirstOrDefault(problem => problem.Id!.Equals(id));
    }

    [HttpPost("Verify/{id}")]
    public ActionResult CheckProblem([FromRoute] String id, List<String> vals)
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

        IEnumerable<String?> blocks = ProblemBlock.ParseProblemString(problem.Chunks!)
            .Where((chunk) => chunk.IsInput).Select((chunk, _) => chunk.Content);

        // Zip/Select does interleave
        List<String?> args = vals.Zip(blocks, (val, block) => new { Val = val, Block = block })
            .SelectMany((pack) => new[] { pack.Val, pack.Block }).ToList();
        
        String matches = TokenMatch(args);

        List<Int32> res = matches.Split(new[] {"\n", "\r\n", "\r"}, StringSplitOptions.RemoveEmptyEntries)
            .Select((str, _) => Int32.Parse(str)).ToList();
        
        Console.Write("Python list: ");
        foreach (Int32 i in res)
            Console.Write($"{i} ");
        Console.WriteLine();
        
        return Ok(res);
    }
    
    [NonAction]
    private String TokenMatch(List<String?> args)
    {
        args.Insert(0, "Python/token-match.py");

        var startInfo = new ProcessStartInfo
        {
            FileName = "python3",
            RedirectStandardOutput = true,
            CreateNoWindow = true
        };
        foreach (String? a in args) {
            startInfo.ArgumentList.Add(a!);
        }

        var process = new Process
        {
            StartInfo = startInfo
        };
        process.Start();
        String output = process.StandardOutput.ReadToEnd();
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
    public ActionResult GetCampaignLevel(Int32 level)
    {
        String jsonText = System.IO.File.ReadAllText("Files/campaign-levels.json");
        var levels = JsonSerializer.Deserialize<List<String>>(jsonText)!;

        if (level >= levels.Count)
        {
            return BadRequest("Level out of bounds");
        }

        return Ok(levels[level]);
    }
}