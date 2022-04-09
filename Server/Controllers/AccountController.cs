using codedash.Shared;
using Microsoft.AspNetCore.Mvc;

namespace codedash.Server.Controllers;

[ApiController]
[Route("AccountApi")]
public class RegisterController : ControllerBase
{
    private readonly AccountDbContext _context;
    private readonly TokenDbContext _tokenContext;

    public RegisterController(AccountDbContext context, TokenDbContext tokenContext)
    {
        _context = context;
        _tokenContext = tokenContext;
    }
    
    [HttpPost]
    [Route("Register")]
    public ActionResult Register(Account account)
    {
        try
        {
            AddToDb(account);
            string tokenString = TokenGen.GenerateToken().ToLowerInvariant();
            RegisterToken(new Token
            {
                Id = Guid.NewGuid().ToString().ToLowerInvariant(),
                TokenString = tokenString,
                UsernameHash = account.UsernameHash
            });
            return Ok(tokenString);
        }
        catch (Exception e)
        {
            return new StatusCodeResult(StatusCodes.Status500InternalServerError);
        }
    }
    
    [NonAction]
    private async Task AddToDb(Account account)
    {
        _context.Add(account);
        await _context.SaveChangesAsync();
    }

    [NonAction]
    private async Task RegisterToken(Token token)
    {
        _tokenContext.Add(token);
        await _tokenContext.SaveChangesAsync();
    }

    [HttpPost]
    [Route("Login")]
    public ActionResult Login(Account account)
    {
        bool result = ValidateAccount(account);
        if (!result) return NotFound();
        
        // Delete old tokens by scanning through the database
        List<Token> items = _tokenContext.Token!.ToList();
        foreach (Token item in items.Where(x => x.UsernameHash!.Equals(account.UsernameHash))) _tokenContext.Token!.Remove(item);
        _tokenContext.SaveChanges();

        // Generate a new token
        string tokenString = TokenGen.GenerateToken().ToLowerInvariant();
        RegisterToken(new Token
        {
            Id = Guid.NewGuid().ToString().ToLowerInvariant(),
            TokenString = tokenString,
            UsernameHash = account.UsernameHash
        });
        return Ok(tokenString);
    }

    [NonAction]
    public bool ValidateAccount(Account query)
    {
        // Search for account with specified username
        Account? result = _context.Account!.FirstOrDefault(acc => acc.UsernameHash == query.UsernameHash);
        return result != null && query.PasswordHash!.Equals(result!.PasswordHash);
    }
}