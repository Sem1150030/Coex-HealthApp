namespace HealthApp_Backend.Models.DomainModels;

public class FoodItem
{
    public Guid Id { get; set; }
    public string name { get; set; }
    public int kcalAmount { get; set; }
    public float proteinAmount { get; set; }
    public string measurement { get; set; }
    public Guid userId { get; set; }


}