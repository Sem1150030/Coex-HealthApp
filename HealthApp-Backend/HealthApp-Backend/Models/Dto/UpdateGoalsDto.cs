namespace HealthApp_Backend.Models.Dto;

public class UpdateGoalsDto
{
    public int KcalGoal { get; set; }
    public int proteinGoal { get; set; }
    public int carbGoal { get; set; }
    public int fatGoal { get; set; }
    public bool kcalMax { get; set; }
}