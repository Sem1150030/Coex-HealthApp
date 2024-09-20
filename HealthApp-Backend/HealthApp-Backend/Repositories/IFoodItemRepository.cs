using HealthApp_Backend.Models.DomainModels;

namespace HealthApp_Backend.Repositories;

public interface IFoodItemRepository
{
    Task<List<FoodItem>> GetAllFoodItemsAsync();
    Task<FoodItem> CreateFoodItemAsync(FoodItem foodItem);
    Task<FoodItem?> GetFoodItemByIdAsync(Guid id);
}