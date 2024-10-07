using HealthApp_Backend.Models.DomainModels;

namespace HealthApp_Backend.Repositories;

public interface IWeightRepository
{
    Task<List<WeightTracker>> getWeightDataAsync(Guid userId);
    Task<WeightTracker> getWeightDataTodayAsync(Guid userId, DateTime date);
}