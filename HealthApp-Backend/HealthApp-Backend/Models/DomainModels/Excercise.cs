namespace HealthApp_Backend.Models.DomainModels;

public class Exercise
{
    public Guid Id { get; set; } // Primary Key
    public string Name { get; set; } // Name of the exercise
    public List<Set> Sets { get; set; } // List of sets for the exercise
    public Guid WorkoutId { get; set; } // Foreign Key to Workout
    public Guid userId { get; set; } // User ID for the exercise

    public Exercise()
    {
        Sets = new List<Set>();
    }
}