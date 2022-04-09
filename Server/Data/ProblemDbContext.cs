using Microsoft.EntityFrameworkCore;

namespace codedash.Shared;

public class ProblemDbContext : DbContext
{
    #region Contructor
    public ProblemDbContext(DbContextOptions<ProblemDbContext> options) : base(options)
    {
    
    }
    #endregion

    #region Public properties
    public DbSet<Problem>? Problem { get; set; }
    #endregion

    #region Overidden methods
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Problem>().HasData(GetProblems());
        base.OnModelCreating(modelBuilder);
    }
    #endregion


    #region Private methods

    private static IEnumerable<Problem> GetProblems()
    {
        return new List<Problem>
        {
            new() { Id = Guid.NewGuid(), Chunks = $"\x0002ayay\x001f0\x001f1\x001f-1\x001e\x001f9\x001f1\x001f1\x001f2\x0003"}
        };
    }

    #endregion
}