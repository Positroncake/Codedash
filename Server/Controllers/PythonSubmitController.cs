using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace codedash.Server.Controllers;

[ApiController]
[Route("SubmitApi")]
public class PythonSubmitController : ControllerBase
{
    [HttpPost]
    [Route("PythonSubmit")]
    public ActionResult Create(List<string> code)
    {
        // Store output so we can return it to the user
        List<string> output = new();
        
        // Store received text into a python file
        string path = $"Files/{Guid.NewGuid()}.py";
        FileStream fs = System.IO.File.Create(path);
        fs.Close();
        StreamWriter sw = new(path, true);
        foreach (string line in code) sw.WriteLineAsync(line);
        sw.Close();
        
        // Run the file
        var process = new Process
        {
            StartInfo = new ProcessStartInfo
            {
                FileName = "python3",
                Arguments = path,
                RedirectStandardOutput = true,
                CreateNoWindow = true
            }
        };
        // Start process and return to user
        process.Start();
        while (!process.StandardOutput.EndOfStream) output.Add(process.StandardOutput.ReadLine()!);
        return Ok(output);
    }
}