using HealthApp_Backend.Models.DomainModels;

namespace HealthApp_Backend.Repositories;

public interface IWorkoutRepository
{
    Task<List<Workout>> getWorkoutDataByUserIdAsync(Guid userId);

}