using Codedash.Shared;
using Microsoft.EntityFrameworkCore;

namespace Codedash.Server.Data;

public class TokenDbContext : DbContext
{
    #region Contructor

    public TokenDbContext(DbContextOptions<TokenDbContext> options) : base(options)
    {
    }

    #endregion

    #region Public properties

    public DbSet<Token>? Token { get; set; }

    #endregion

    #region Overidden methods

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Token>().HasData(GetTokens());
        base.OnModelCreating(modelBuilder);
    }

    #endregion


    #region Private methods

    private static IEnumerable<Token> GetTokens()
    {
        return new List<Token>
        {
            new()
            {
                Id = Guid.NewGuid().ToString().ToLowerInvariant(),
                TokenString = TokenGen.GenerateToken(),
                UsernameHash = "3a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e"
            },
            new()
            {
                Id = Guid.NewGuid().ToString().ToLowerInvariant(),
                TokenString = TokenGen.GenerateToken(),
                UsernameHash = "4a2bdfc8841a6b57e71e90983ccd34cd7c8950d2d59506c9df7565978d1891ab11c7c2fc8948d1109eb098e8d016e2d4999a404d0e15ae0ce5637b0482446c0e"
            }
        };
    }

    #endregion
}