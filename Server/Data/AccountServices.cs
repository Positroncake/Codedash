using Codedash.Shared;
using Microsoft.EntityFrameworkCore;

namespace Codedash.Server.Data;

public class AccountServices
{
    #region Private members
    private AccountDbContext dbContext;
    #endregion

    #region Constructor
    public AccountServices(AccountDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Public methods
    public async Task<List<Account>> GetAccountAsync()
    {
        return await dbContext.Account!.ToListAsync();
    }

    public async Task<Account> AddAccountAsync(Account account)
    {
        dbContext.Account!.Add(account);
        await dbContext.SaveChangesAsync();
        return account;
    }
    
    public async Task<Account> UpdateAccountAsync(Account account)
    {
        Account? productExist = dbContext.Account!.FirstOrDefault(p => p.Id == account.Id);
        if (productExist == null) return account;
        dbContext.Update(account);
        await dbContext.SaveChangesAsync();

        return account;
    }
    
    public async Task DeleteAccountAsync(Account account)
    {
        dbContext.Account!.Remove(account);
        await dbContext.SaveChangesAsync();
    }
    #endregion
}