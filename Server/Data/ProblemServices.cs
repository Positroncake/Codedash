using Codedash.Shared;
using Microsoft.EntityFrameworkCore;

namespace Codedash.Server.Data;

public class ProblemServices
{
    #region Private members
    private ProblemDbContext dbContext;
    #endregion

    #region Constructor
    public ProblemServices(ProblemDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    #endregion

    #region Public methods
    public async Task<List<Problem>> GetProblemAsync()
    {
        return await dbContext.Problem!.ToListAsync();
    }

    public async Task<Problem> AddProblemAsync(Problem problem)
    {
        dbContext.Problem!.Add(problem);
        await dbContext.SaveChangesAsync();
        return problem;
    }
    
    public async Task<Problem> UpdateProblemAsync(Problem problem)
    {
        Problem? productExist = dbContext.Problem!.FirstOrDefault(p => p.Id == problem.Id);
        if (productExist == null) return problem;
        dbContext.Update(problem);
        await dbContext.SaveChangesAsync();

        return problem;
    }
    
    public async Task DeleteProblemAsync(Problem problem)
    {
        dbContext.Problem!.Remove(problem);
        await dbContext.SaveChangesAsync();
    }
    #endregion
}