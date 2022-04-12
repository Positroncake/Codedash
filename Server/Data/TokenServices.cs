using Codedash.Shared;
using Microsoft.EntityFrameworkCore;

namespace Codedash.Server.Data;

public class TokenServices
{
    #region Private members
    private TokenDbContext dbContext;
    #endregion

    #region Constructor
    public TokenServices(TokenDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Public methods
    public async Task<List<Token>> GetTokenAsync()
    {
        return await dbContext.Token!.ToListAsync();
    }

    public async Task<Token> AddTokenAsync(Token token)
    {
        dbContext.Token!.Add(token);
        await dbContext.SaveChangesAsync();
        return token;
    }
    
    public async Task<Token> UpdateTokenAsync(Token token)
    {
        Token? productExist = dbContext.Token!.FirstOrDefault(p => p.Id == token.Id);
        if (productExist == null) return token;
        dbContext.Update(token);
        await dbContext.SaveChangesAsync();

        return token;
    }
    
    public async Task DeleteTokenAsync(Token token)
    {
        dbContext.Token!.Remove(token);
        await dbContext.SaveChangesAsync();
    }
    #endregion
}