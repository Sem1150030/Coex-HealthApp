namespace HealthApp_Backend.Models.Dto;

public class UpdateSetDto
{
    public Guid Id { get; set; } // Primary Key
    public int Reps { get; set; } // Number of repetitions
    public decimal Weight { get; set; } // Weight used in the set
    public Guid ExerciseId { get; set; } // Foreign Key to Exercise
    
}