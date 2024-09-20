using AutoMapper;
using HealthApp_Backend.Models.DomainModels;
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
    
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetFoodItemById(Guid id)
    {
        var foodItem = await foodItemRepository.GetFoodItemByIdAsync(id);
        return Ok(mapper.Map<FoodItemDto>(foodItem));
    }

    [HttpPost]
    
    public async Task<IActionResult> CreateFoodItem([FromBody] CreateFoodItemDto foodItemDto)
    {
        var shoppingListFoodItems = new List<ShoppingListFoodItem>();
        
        var shoppingListFoodItemDtos = mapper.Map<List<ShoppingListFoodItemDto>>(shoppingListFoodItems);
        var userId = "7533E49E-EB8D-4E6B-8EF6-848EB43ED294";

        
        var CreateFoodItemMappingDto = new CreateFoodItemMappingDto()
        {
             name = foodItemDto.name,
             kcalAmount = foodItemDto.kcalAmount,
             proteinAmount = foodItemDto.proteinAmount,
             measurement = foodItemDto.measurement,
             ShoppingListFoodItems = shoppingListFoodItemDtos,
             userId = Guid.Parse(userId)
        };
        var foodItem = mapper.Map<FoodItem>(CreateFoodItemMappingDto);
        
        
        
        await foodItemRepository.CreateFoodItemAsync(foodItem);
        return Ok("Food item created");
    }
    
} 