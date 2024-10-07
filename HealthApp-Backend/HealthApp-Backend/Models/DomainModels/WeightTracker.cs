using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices.JavaScript;

namespace HealthApp_Backend.Models.DomainModels;

public class WeightTracker
{
    public Guid Id { get; set; }
    public Guid UserId { get; set; }
    public DateTime Date { get; set; }
   
    public float Weight { get; set; }
    
    public float WeightGoal { get; set; }
}