using HealthApp_Backend.Data;
using HealthApp_Backend.Models.DomainModels;
using HealthApp_Backend.Models.Dto;
using Microsoft.EntityFrameworkCore;

namespace HealthApp_Backend.Repositories;

public class SQLWeightRepository: IWeightRepository
{
    private readonly HealthAppDbContext dbContext;

    
    public SQLWeightRepository(HealthAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<WeightTracker>> getWeightDataAsync(Guid userId)
    {
        var data = await dbContext.WeightTrackers.Where(x => x.UserId == userId).ToListAsync();
        return data;
    }

    public async Task<WeightTracker> getWeightDataTodayAsync(Guid userId, DateTime date)
    {
        var data = await dbContext.WeightTrackers.FirstOrDefaultAsync(x => x.UserId == userId && x.Date == date);
        if (data == null)
        {
            var lastKnownData = await dbContext.WeightTrackers.Where(x => x.UserId == userId).
                OrderByDescending(x => x.Date).FirstOrDefaultAsync();

            if (lastKnownData == null)
            {
                 data = new WeightTracker()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Date = date,
                    Weight = 0F,
                    WeightGoal = 0F
                };
                 
                await dbContext.WeightTrackers.AddAsync(data);
                await dbContext.SaveChangesAsync();
                return data;
            }
            else
            {
                 data = new WeightTracker()
                {
                    Id = Guid.NewGuid(),
                    UserId = userId,
                    Date = date,
                    Weight = lastKnownData.Weight,
                    WeightGoal = lastKnownData.WeightGoal
                };
                await dbContext.WeightTrackers.AddAsync(data);
                await dbContext.SaveChangesAsync();
                return data;
            }
        }

        return data;
    }

    public async Task<WeightTracker> updateWeightDataAsync(Guid userId, DateTime date, WeightRequestDto weightRequestDto)
    {
        var weightDataOfToday = await getWeightDataTodayAsync(userId, DateTime.Now.Date);
        weightDataOfToday.WeightGoal = weightRequestDto.WeightGoal;
        weightDataOfToday.Weight = weightRequestDto.Weight;
        await dbContext.SaveChangesAsync();
        return weightDataOfToday;
    }
}