using HealthApp_Backend.Models.DomainModels;

namespace HealthApp_Backend.Repositories;

public interface IShoppingListrepository
{
    Task<List<ShoppingList>> GetAllShoppingListItemsAsync();
}