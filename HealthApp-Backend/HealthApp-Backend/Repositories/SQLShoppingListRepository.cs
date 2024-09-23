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

    public async Task<ShoppingListFoodItem> AddItemToShoppingListAsync(ShoppingListFoodItem shoppingListFoodItem , DateTime date)
    {
        await dbContext.ShoppingListFoodItems.AddAsync(shoppingListFoodItem);
        await dbContext.SaveChangesAsync();
        return shoppingListFoodItem;

    }

    public async Task<ShoppingList> GetShoppingListByUIDAndDateAsync(Guid userId, DateTime date)
    {
        var shoppingList = await dbContext.ShoppingLists.Include(sl => sl.ShoppingListFoodItems)
            .ThenInclude(slfi => slfi.FoodItem).FirstOrDefaultAsync(x => x.UserId == userId && x.CreatedOn == date);
        if (shoppingList == null)
        {
            var createShoppingList = new ShoppingList()
            {
                Id = Guid.NewGuid(),
                CreatedOn = DateTime.Now.Date,
                UserId = userId,
                KcalGoal = 2000,
                proteinGoal = 100,
                kcalMax = true,
                proteinCurrent = 0,
                kcalCurrent = 0
            };
            await dbContext.ShoppingLists.AddAsync(createShoppingList);
            await dbContext.SaveChangesAsync();
            Console.WriteLine("ShoppingList created");
            return createShoppingList;
        }
        return shoppingList;
    }
}