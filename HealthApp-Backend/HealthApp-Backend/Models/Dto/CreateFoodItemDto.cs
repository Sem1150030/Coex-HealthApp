namespace HealthApp_Backend.Models.Dto;

public class CreateFoodItemDto
{
    public string name { get; set; }
    public int kcalAmount { get; set; }
    public float proteinAmount { get; set; }
    public string measurement { get; set; }
   
}