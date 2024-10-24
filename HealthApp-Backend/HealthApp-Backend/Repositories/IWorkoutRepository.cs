using HealthApp_Backend.Models.DomainModels;
using HealthApp_Backend.Models.Dto;

namespace HealthApp_Backend.Repositories;

public interface IWorkoutRepository
{
    Task<List<Workout>> getWorkoutDataByUserIdAsync(Guid userId);
    Task<Workout> AddWorkout(Guid userId, string name);
    Task<Exercise> AddExercise(Guid workoutId, string name, Guid userId);
    Task<Set> AddSet(Guid exerciseId, int reps, decimal weight, Guid userId);
    Task<Set?> UpdateSet(UpdateSetDto addSetDto, Guid userId);
    Task<Set?> DeleteSet(Guid setId, Guid userId);

}