using System.Security.Claims;
using AutoMapper;
using HealthApp_Backend.Models.Dto;
using HealthApp_Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HealthApp_Backend.Controllers;

[ApiController]
[Authorize]
[EnableCors("AllowSpecificOrigin")]
[Route("[controller]")]
public class WorkoutController : Controller
{

    private readonly IShoppingListrepository iShoppingListrepository;
    private readonly IMapper mapper;
    private readonly IFoodItemRepository foodItemRepository;
    private readonly IWorkoutRepository iWorkoutRepository;



    public WorkoutController(IWorkoutRepository iWorkoutRepository, IMapper mapper,
        IFoodItemRepository foodItemRepository)
    {
        this.iWorkoutRepository = iWorkoutRepository;
        this.mapper = mapper;
        this.foodItemRepository = foodItemRepository;
    }

    [HttpGet]
    [Route("/Workout/user")]
    public async Task<IActionResult> getWorkoutDataByUser()
    {
        
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        var workoutData = await iWorkoutRepository.getWorkoutDataByUserIdAsync(Guid.Parse(userIdString));
        return Ok(workoutData);
    }

    [HttpPost]
    [Route("/Workout/addworkout")]
    public async Task<IActionResult> AddWorkout([FromBody] AddWorkoutDto addWorkoutDto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        
        var workout = await iWorkoutRepository.AddWorkout(Guid.Parse(userIdString), addWorkoutDto.Name);
        return Ok(workout);
    }
    
    [HttpPost]
    [Route("/Workout/addexercise")]
    public async Task<IActionResult> AddExercise([FromBody] AddExerciseDto addExerciseDto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        
        var workout = await iWorkoutRepository.AddExercise( addExerciseDto.WorkoutId, addExerciseDto.Name, Guid.Parse(userIdString));
        return Ok(workout);
    }
    
    [HttpPost]
    [Route("/Workout/addset")]
    public async Task<IActionResult> AddSet([FromBody] AddSetDto addSetDto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        var workout = await iWorkoutRepository.AddSet(addSetDto.ExerciseId, addSetDto.Reps, addSetDto.Weight, Guid.Parse(userIdString));
        return Ok(workout);
    } 
    
    [HttpPut]
    [Route("/Workout/UpdateSet")]
    public async Task<IActionResult> UpdateSet([FromBody] UpdateSetDto updateSetDto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        var workout = await iWorkoutRepository.UpdateSet(updateSetDto, Guid.Parse(userIdString));
        return Ok(workout);
    }

    [HttpDelete]
    [Route("/Workout/DeleteSet/{setId:Guid}")]
    public async Task<IActionResult> DeleteSet(Guid setId)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        var workout = await iWorkoutRepository.DeleteSet(setId, Guid.Parse(userIdString));
        if (workout == null)
        {
            return NotFound("Set_Id not found or does not belong to user");
        }
        
        return Ok(workout);
    }
  
}