using Codedash.Shared;
using Microsoft.EntityFrameworkCore;

namespace Codedash.Server.Data;

public class AccountDbContext : DbContext
{
    #region Contructor
    public AccountDbContext(DbContextOptions<AccountDbContext> options) : base(options)
    {
    
    }
    #endregion

    #region Public properties
    public DbSet<Account>? Account { get; set; }
    #endregion

    #region Overidden methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>().HasData(GetAccounts());
        base.OnModelCreating(modelBuilder);
    }
    #endregion


    #region Private methods

    private static IEnumerable<Account> GetAccounts()
    {
        return new List<Account>
        {
            new()
            {
                Id = Guid.NewGuid().ToString().ToLowerInvariant(),
                UsernameHash = "3a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e",
                PasswordHash = "c2015c71296c09ac3279d2d27a35b0fd58bb39f5b184a160f52e39c495056494f2eae2c84bc90f24013580bf9e34c318c98c27a85d0b88e63f4ef4c695d6699b",
                DisplayName = "Generic PCI Device",
                Solved = 0,
                AverageTime = 0m,
                SubmissionsNum = 0,
                Submissions = string.Empty,
                RegistrationDate = DateTime.UtcNow
            },
            new()
            {
                Id = Guid.NewGuid().ToString().ToLowerInvariant(),
                UsernameHash = "4a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e",
                PasswordHash = "d2015c71296c09ac3279d2d27a35b0fd58bb39f5b184a160f52e39c495056494f2eae2c84bc90f24013580bf9e34c318c98c27a85d0b88e63f4ef4c695d6699b",
                DisplayName = "Generic electron",
                Solved = 0,
                AverageTime = 0m,
                SubmissionsNum = 0,
                Submissions = string.Empty,
                RegistrationDate = DateTime.UtcNow
            }
        };
    }

    #endregion
}