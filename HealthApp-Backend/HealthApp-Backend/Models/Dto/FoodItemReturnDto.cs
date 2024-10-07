namespace HealthApp_Backend.Models.Dto;

public class FoodItemReturnDto
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public int KcalAmount { get; set; }
    public float ProteinAmount { get; set; }
    public float fatAmount { get; set; }
    public float carbAmount { get; set; }

    public List<ShoppingListFoodItemDto> ShoppingListFoodItems { get; set; }
    public string Measurement { get; set; }
   
}