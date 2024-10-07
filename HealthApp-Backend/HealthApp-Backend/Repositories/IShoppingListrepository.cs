using HealthApp_Backend.Models.DomainModels;

namespace HealthApp_Backend.Repositories;

public interface IShoppingListrepository
{
    Task<List<ShoppingList>> GetAllShoppingListItemsAsync();
    Task<ShoppingList?> GetShoppingListPerId(Guid id);
    Task<ShoppingListFoodItem> AddItemToShoppingListAsync(ShoppingListFoodItem shoppingListFoodItem, DateTime date);
    Task<ShoppingList> GetShoppingListByUIDAndDateAsync(Guid userId, DateTime date);
    Task<ShoppingList?> updateShoppingListAsync(int newKcal, float newProtein,  float newFat, float newCarb, Guid userId, DateTime date);
    Task<ShoppingListFoodItem?> deleteItemFromShoppingListAsync(Guid shoppingListFoodItemId);
}