namespace HealthApp_Backend.Models.Dto;

public class ShoppingListFoodItemDto
{
    public Guid Id { get; set; }
    // public Guid ShoppingListId { get; set; }
    // public Guid FoodItemId { get; set; }
    public FoodItemDto FoodItem { get; set; } // Include FoodItem details if needed
}