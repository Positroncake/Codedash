using Microsoft.AspNetCore.Mvc;

namespace codedash.Server.Controllers;

[ApiController]
[Route("ProblemApi")]
public class ProblemController : ControllerBase {
    [HttpGet("ByID/{index:int}")]
    public ActionResult GetProblemByID(int index) {
        return Ok($"Received: {index.ToString()}");
    }
};