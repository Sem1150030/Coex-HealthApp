using AutoMapper;
using HealthApp_Backend.Models.Dto;
using HealthApp_Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HealthApp_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class FoodItemController : Controller
{
    
    private readonly IMapper mapper;
    private readonly IFoodItemRepository foodItemRepository;

    public FoodItemController(IMapper mapper, IFoodItemRepository foodItemRepository)
    {
        this.mapper = mapper;
        this.foodItemRepository = foodItemRepository;
        
    }


    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var fooditems = await foodItemRepository.GetAllFoodItemsAsync();
        return Ok(mapper.Map<List<FoodItemDto>>(fooditems));
    }
    
}