namespace HealthApp_Backend.Models.DomainModels;

public class ShoppingListFoodItem
{
    public Guid Id { get; set; }
    
    public Guid ShoppingListId { get; set; }
    public ShoppingList ShoppingList { get; set; } // Navigation property

    public Guid FoodItemId { get; set; }
    public FoodItem FoodItem { get; set; } // Navigation property

}