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
            var createShoppingList = new ShoppingList();
            
            var latestShoppingList = await dbContext.ShoppingLists.Include(sl => sl.ShoppingListFoodItems)
                .ThenInclude(slfi => slfi.FoodItem).Where(x => x.UserId == userId).OrderByDescending(x => x.CreatedOn).FirstOrDefaultAsync();
            if (latestShoppingList == null)
            {
                 createShoppingList = new ShoppingList()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now.Date,
                    UserId = userId,
                    KcalGoal = 2000,
                    proteinGoal = 100,
                    carbGoal = 250,
                    fatGoal = 50,
                        
                    kcalMax = true,
                    proteinCurrent = 0,
                    kcalCurrent = 0,
                    fatCurrent = 0,
                    carbCurrent = 0
                };
            }
            else
            {
                 createShoppingList = new ShoppingList()
                {
                    Id = Guid.NewGuid(),
                    CreatedOn = DateTime.Now.Date,
                    UserId = userId,
                    KcalGoal = latestShoppingList.KcalGoal,
                    proteinGoal = latestShoppingList.proteinGoal,
                    carbGoal = latestShoppingList.carbGoal,
                    fatGoal = latestShoppingList.fatGoal,
                    
                    kcalMax = latestShoppingList.kcalMax,
                    
                    proteinCurrent = 0,
                    kcalCurrent = 0,
                    fatCurrent = 0,
                    carbCurrent = 0
                };
            }

            await dbContext.ShoppingLists.AddAsync(createShoppingList);
            await dbContext.SaveChangesAsync();
            Console.WriteLine("ShoppingList created");
            return createShoppingList;
        }
        return shoppingList;
    }

    public async Task<ShoppingList?> updateShoppingListAsync(int newKcal, float newProtein, float newFat, float newCarb, Guid userId, DateTime date)
    {
        var currentShoppingList = await dbContext.ShoppingLists.Include(sl => sl.ShoppingListFoodItems)
            .ThenInclude(slfi => slfi.FoodItem).FirstOrDefaultAsync(x => x.UserId == userId && x.CreatedOn == date);

        if (currentShoppingList == null)
        {
            return null;
        }
        
        currentShoppingList.kcalCurrent = newKcal;
        currentShoppingList.proteinCurrent = newProtein;
        currentShoppingList.fatCurrent = newFat;
        currentShoppingList.carbCurrent = newCarb;
        await dbContext.SaveChangesAsync();
        return currentShoppingList;
    }

    public async Task<ShoppingListFoodItem?> deleteItemFromShoppingListAsync(Guid shoppingListFoodItemId)
    {
        var checkIfItemExists = await dbContext.ShoppingListFoodItems.FirstOrDefaultAsync(x => x.Id == shoppingListFoodItemId);
        if(checkIfItemExists == null)
        {
            return null;
        }
        dbContext.ShoppingListFoodItems.Remove(checkIfItemExists);
        await dbContext.SaveChangesAsync();
        return checkIfItemExists;
    }
}