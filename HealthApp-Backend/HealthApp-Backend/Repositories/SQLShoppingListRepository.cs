using HealthApp_Backend.Data;
using HealthApp_Backend.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace HealthApp_Backend.Repositories;

public class SQLShoppingListRepository: IShoppingListrepository
{
    private readonly HealthAppDbContext dbContext;

    
    public SQLShoppingListRepository(HealthAppDbContext dbContext)
    {
        this.dbContext = dbContext;
    }
    
    public async Task<List<ShoppingList>> GetAllShoppingListItemsAsync()
    {
        return await dbContext.ShoppingLists
            .Include(sl => sl.ShoppingListFoodItems)
            .ThenInclude(slfi => slfi.FoodItem)
            .ToListAsync();
    }
}