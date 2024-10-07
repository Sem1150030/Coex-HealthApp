using System.ComponentModel.DataAnnotations;

namespace HealthApp_Backend.Models.Dto;

public class WeightRequestDto
{
    public float Weight { get; set; }
    
    public float WeightGoal { get; set; }
}