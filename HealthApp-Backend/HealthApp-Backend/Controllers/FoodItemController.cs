using System.Security.Claims;
using AutoMapper;
using HealthApp_Backend.Models.DomainModels;
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
    
    [HttpGet]
    [Route("User")]
    public async Task<IActionResult> GetAllByUId()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        var userId = Guid.Parse(userIdString);
        var fooditems = await foodItemRepository.GetAllFoodItemsByUIDAsync(userId);
        
        return Ok(mapper.Map<List<FoodItemDto>>(fooditems));
    }
    
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetFoodItemById(Guid id)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        var userId = Guid.Parse(userIdString);
        var foodItem = await foodItemRepository.GetFoodItemByIdAsync(id, userId);
        return Ok(mapper.Map<FoodItemDto>(foodItem));
    }

    [HttpPost]
    public async Task<IActionResult> CreateFoodItem([FromBody] CreateFoodItemDto foodItemDto)
    {
        var shoppingListFoodItems = new List<ShoppingListFoodItem>();
        var shoppingListFoodItemDtos = mapper.Map<List<ShoppingListFoodItemDto>>(shoppingListFoodItems);
        
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        var userId = Guid.Parse(userIdString);

        
        var CreateFoodItemMappingDto = new CreateFoodItemMappingDto()
        {
             name = foodItemDto.name,
             kcalAmount = foodItemDto.kcalAmount,
             proteinAmount = foodItemDto.proteinAmount,
                carbAmount = foodItemDto.carbAmount,
                fatAmount = foodItemDto.fatAmount,
             measurement = foodItemDto.measurement,
             ShoppingListFoodItems = shoppingListFoodItemDtos,
             userId = userId
        };
        var foodItem = mapper.Map<FoodItem>(CreateFoodItemMappingDto);
        
        
        
        await foodItemRepository.CreateFoodItemAsync(foodItem);
        return Ok(foodItem);
    }
    
} 