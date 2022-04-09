using codedash.Shared;
using Microsoft.AspNetCore.Mvc;

namespace codedash.Server.Controllers;

[ApiController]
[Route("AccountApi")]
public class RegisterController : ControllerBase
{
    private readonly AccountDbContext _context;

    public RegisterController(AccountDbContext context)
    {
        _context = context;
    }
    
    [HttpPost]
    [Route("Register")]
    public ActionResult Register(Account account)
    {
        try
        {
            AddToDb(account);
            return Ok(new[] {account.UsernameHash, account.PasswordHash, account.DisplayName});
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

    [HttpPost]
    [Route("Login")]
    public ActionResult Login(Account account)
    {
        (bool result, string? displayName) = ValidateAccount(account);
        if (result) return Ok(displayName);
        return NotFound();
    }
    
    // note to Chris: KEEP THIS HERE
    [NonAction]
    public (bool, string?) ValidateAccount(Account query)
    {
        // Search for account with specified username
        Account? result = _context.Account!.FirstOrDefault(acc => acc.UsernameHash == query.UsernameHash);
        // If account not found
        if (result is null) return (false, "");
        // If account is found validate password
        // ReSharper disable once ConvertIfStatementToReturnStatement
        if (query.PasswordHash!.Equals(result!.PasswordHash))
        {
            // If password is valid fetch and return display name
            return (true, result.DisplayName);
        }
        // If password is invalid return an empty display name
        return (false, "");
    }
}