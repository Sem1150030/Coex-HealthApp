namespace HealthApp_Backend.Models.DomainModels;

public class ShoppingList
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<FoodItem> FoodItems { get; set; }
    public Guid UserId { get; set; }
    public int KcalGoal { get; set; }
    public int proteinGoal { get; set; }
    public bool kcalMax { get; set; }
    public float proteinCurrent { get; set; }
    public int kcalCurrent { get; set; }
}