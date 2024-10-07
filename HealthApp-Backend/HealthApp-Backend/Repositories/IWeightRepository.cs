using HealthApp_Backend.Models.DomainModels;
using HealthApp_Backend.Models.Dto;

namespace HealthApp_Backend.Repositories;

public interface IWeightRepository
{
    Task<List<WeightTracker>> getWeightDataAsync(Guid userId);
    Task<WeightTracker> getWeightDataTodayAsync(Guid userId, DateTime date);
    Task<WeightTracker> updateWeightDataAsync(Guid userId, DateTime date, WeightRequestDto weightRequestDto);
}