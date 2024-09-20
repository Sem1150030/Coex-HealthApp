namespace HealthApp_Backend.Models.Dto;

public class ShoppingListFoodItemRequestDto
{
    public Guid ShoppingListId { get; set; }
    public Guid FoodItemId { get; set; }
}