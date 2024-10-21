namespace HealthApp_Backend.Models.DomainModels;

public class Workout
{
    public Guid Id { get; set; } // Primary Key
    public string Name { get; set; } // Name of the workout
    public DateTime Date { get; set; } // Date of the workout
    public List<Exercise> Exercises { get; set; } // List of exercises
    public Guid userId { get; set; } // User ID for the workout

    public Workout()
    {
        Exercises = new List<Exercise>();
    }
}