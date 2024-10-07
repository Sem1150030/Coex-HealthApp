namespace HealthApp_Backend.Models.Dto;

public class ShoppingListReturnDto
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<ShoppingListFoodItemDto> ShoppingListFoodItems { get; set; }
    public Guid UserId { get; set; }
    public int KcalGoal { get; set; }
    public int proteinGoal { get; set; }
    public int carbGoal { get; set; }
    public int fatGoal { get; set; }
    public bool kcalMax { get; set; }
    
    public float proteinCurrent { get; set; }
    public int kcalCurrent { get; set; }
    public int carbCurrent { get; set; }
    public int fatCurrent { get; set; }
}
