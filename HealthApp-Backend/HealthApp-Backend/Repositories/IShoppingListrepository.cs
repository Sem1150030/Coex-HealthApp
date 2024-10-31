using HealthApp_Backend.Models.DomainModels;

namespace HealthApp_Backend.Repositories;

public interface IShoppingListrepository
{
    Task<List<ShoppingList>> GetAllShoppingListItemsAsync(Guid userId);
    Task<ShoppingList?> GetShoppingListPerId(Guid id, Guid userId);
    Task<ShoppingListFoodItem> AddItemToShoppingListAsync(ShoppingListFoodItem shoppingListFoodItem, DateTime date);
    Task<ShoppingList> GetShoppingListByUIDAndDateAsync(Guid userId, DateTime date);
    Task<ShoppingList?> updateShoppingListAsync(int newKcal, float newProtein,  float newFat, float newCarb, Guid userId, DateTime date);
    Task<ShoppingListFoodItem?> deleteItemFromShoppingListAsync(Guid shoppingListFoodItemId);

    Task<ShoppingList> updateShoppingListGoalsAsync(int newKcalGoal, int newProteinGoal, int newFatGoal,
        int newCarbGoal, Guid userId, DateTime todaysDate);
}