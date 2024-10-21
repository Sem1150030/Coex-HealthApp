using HealthApp_Backend.Data;
using HealthApp_Backend.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HealthApp_Backend.Repositories;

public class SQLWorkoutRepository : IWorkoutRepository
{
    private readonly HealthAppDbContext dbContext;

    
    public SQLWorkoutRepository(HealthAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    
    public async Task<List<Workout>> getWorkoutDataByUserIdAsync(Guid userId)
    {
        return await dbContext.Workouts
            .Where(w => w.userId == userId) // Filter by userId
            .Include(w => w.Exercises)      // Include related Exercises
            .ThenInclude(e => e.Sets)   // Include Sets for each Exercise
            .ToListAsync();                 // Execute asynchronously
    }
}