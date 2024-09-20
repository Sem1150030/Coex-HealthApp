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

  

    public async Task<ShoppingList?> GetShoppingListPerId(Guid id)
    {
        return await dbContext.ShoppingLists.Include(sl => sl.ShoppingListFoodItems)
            .ThenInclude(slfi => slfi.FoodItem).FirstOrDefaultAsync(x => x.Id == id);

    }

    public async Task<ShoppingListFoodItem> AddItemToShoppingListAsync(ShoppingListFoodItem shoppingListFoodItem)
    {
        await dbContext.ShoppingListFoodItems.AddAsync(shoppingListFoodItem);
        await dbContext.SaveChangesAsync();
        return shoppingListFoodItem;

    }
}