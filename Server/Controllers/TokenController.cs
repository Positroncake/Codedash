using codedash.Server.Data;
using codedash.Shared;
using Microsoft.AspNetCore.Mvc;

namespace codedash.Server.Controllers;

[ApiController]
[Route("TokenApi")]
public class TokenController : ControllerBase
{
    private static TokenDbContext _context = null!;

    public TokenController(TokenDbContext context)
    {
        _context = context;
    }

    [HttpDelete]
    [Route("Logout/{token}")]
    public ActionResult Logout([FromRoute] string token)
    {
        List<Token> items = _context.Token!.ToList();
        foreach (Token item in items.Where(x => x.TokenString!.Equals(token))) _context.Token!.Remove(item);
        _context.SaveChanges();
        return Ok();
    }
}