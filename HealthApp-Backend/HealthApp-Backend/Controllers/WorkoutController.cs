using System.Security.Claims;
using AutoMapper;
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
}