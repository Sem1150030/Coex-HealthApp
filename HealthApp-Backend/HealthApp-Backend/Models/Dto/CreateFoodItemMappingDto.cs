namespace HealthApp_Backend.Models.Dto;

public class CreateFoodItemMappingDto
{
    public string name { get; set; }
    public int kcalAmount { get; set; }
    public float proteinAmount { get; set; }
    public float carbAmount { get; set; }
    public float fatAmount { get; set; }
    public string measurement { get; set; }
    public List<ShoppingListFoodItemDto> ShoppingListFoodItems { get; set; } // Junction table for many-to-many
    public Guid userId { get; set; }
}