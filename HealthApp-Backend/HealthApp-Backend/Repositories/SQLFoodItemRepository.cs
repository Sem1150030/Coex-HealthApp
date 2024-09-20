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

    // Get all food items
    public async Task<List<FoodItem>> GetAllFoodItemsAsync()
    {
        return await dbContext.FoodItems.ToListAsync();
    }
    
    
    // Create a food item
    public async Task<FoodItem> CreateFoodItemAsync(FoodItem foodItem)
    {
        await dbContext.FoodItems.AddAsync(foodItem);
        await dbContext.SaveChangesAsync();
        return foodItem;
    }

    public async Task<FoodItem?> GetFoodItemByIdAsync(Guid id)
    {
        return await dbContext.FoodItems.FirstOrDefaultAsync(x => x.Id == id);
    }
}