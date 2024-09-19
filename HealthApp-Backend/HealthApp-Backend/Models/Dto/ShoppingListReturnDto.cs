namespace HealthApp_Backend.Models.Dto;

public class ShoppingListReturnDto
{
    public Guid Id { get; set; }
    public DateTime CreatedOn { get; set; }
    public List<ShoppingListFoodItemDto> ShoppingListFoodItems { get; set; }
    public Guid UserId { get; set; }
    public int KcalGoal { get; set; }
    public int ProteinGoal { get; set; }
    public bool KcalMax { get; set; }
    public float ProteinCurrent { get; set; }
    public int KcalCurrent { get; set; }
}