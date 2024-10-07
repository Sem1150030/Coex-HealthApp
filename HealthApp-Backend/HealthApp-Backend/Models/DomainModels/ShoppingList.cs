namespace HealthApp_Backend.Models.DomainModels;

public class ShoppingList
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<ShoppingListFoodItem> ShoppingListFoodItems { get; set; } // Junction table for many-to-many
    public Guid UserId { get; set; }
    public int KcalGoal { get; set; }
    public int proteinGoal { get; set; }
    public int carbGoal { get; set; }
    public int fatGoal { get; set; }
    public bool kcalMax { get; set; }
    
    public float proteinCurrent { get; set; }
    public int kcalCurrent { get; set; }
    public float carbCurrent { get; set; }
    public float fatCurrent { get; set; }
}