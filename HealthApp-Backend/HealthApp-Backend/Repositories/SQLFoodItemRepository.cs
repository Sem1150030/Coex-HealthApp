using HealthApp_Backend.Data;
using HealthApp_Backend.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HealthApp_Backend.Repositories;

public class SQLFoodItemRepository: IFoodItemRepository
{
    private readonly HealthAppDbContext dbContext;


    public SQLFoodItemRepository(HealthAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }

    
    public async Task<List<FoodItem>> GetAllFoodItemsAsync()
    {
        return await dbContext.FoodItems.ToListAsync();
    }
}