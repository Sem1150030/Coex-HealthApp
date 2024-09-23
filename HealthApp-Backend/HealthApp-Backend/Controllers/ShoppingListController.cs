using System.Security.Claims;
using AutoMapper;
using HealthApp_Backend.Models.DomainModels;
using HealthApp_Backend.Models.Dto;
using HealthApp_Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HealthApp_Backend.Controllers;

[ApiController]
[Authorize]
[Route("[controller]")]
public class ShoppingListController : Controller
{
    
    private readonly IShoppingListrepository iShoppingListrepository;
    private readonly IMapper mapper;
    private readonly IFoodItemRepository foodItemRepository;

    
    public ShoppingListController(IShoppingListrepository iShoppingListrepository, IMapper mapper, 
        IFoodItemRepository foodItemRepository)
    {
        this.iShoppingListrepository = iShoppingListrepository;
        this.mapper = mapper;
        this.foodItemRepository = foodItemRepository;
    }
    //Dev Only
    [HttpGet]
    public async Task<IActionResult> GetAllShoppingListItems()
    {
        var shoppingListItems = await iShoppingListrepository.GetAllShoppingListItemsAsync();

        
        var shoppingListDtos = mapper.Map<List<ShoppingListReturnDto>>(shoppingListItems);
        
        return Ok(shoppingListDtos);
    }
    
    //Dev Only
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetShoppingListPerId(Guid id)
    {
        
        var shoppingListItems = await iShoppingListrepository.GetShoppingListPerId(id);
        var shoppingListDtos = mapper.Map<ShoppingListReturnDto>(shoppingListItems);
        
        return Ok(shoppingListDtos);
    }
    
    //-----------------------------------------------------
    //Production
    
    [HttpPost]
    [Route("AddItem")]
    public async Task<IActionResult> AddItemToShoppingList([FromBody] ShoppingListFoodItemRequestDto shoppingListFoodItemRequestDto)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        var userId = Guid.Parse(userIdString);
        
        var sLFId = mapper.Map<ShoppingListFoodItem>(shoppingListFoodItemRequestDto);
        var todaysDate = DateTime.Now.Date;
        
        var shoppingList = await iShoppingListrepository.GetShoppingListByUIDAndDateAsync(userId, todaysDate);
        Guid shoppingListId = shoppingList.Id;
        
        var shoppingListFoodItem = new ShoppingListFoodItem
        {
            Id = Guid.NewGuid(), 
            ShoppingListId = shoppingListId,
            FoodItemId = shoppingListFoodItemRequestDto.FoodItemId
        };

        await iShoppingListrepository.AddItemToShoppingListAsync(shoppingListFoodItem, todaysDate);
        return Ok("Added item to shopping list");
    }
    
    [HttpGet]
    [Route("User")]
    public async Task<IActionResult> GetShoppingListByUIdAndDate()
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        var userId = Guid.Parse(userIdString);
        var todaysDate = DateTime.Now.Date;
        
        
        var shoppingListItems = await iShoppingListrepository.GetShoppingListByUIDAndDateAsync(userId, todaysDate);
        var shoppingListDtos = mapper.Map<ShoppingListReturnDto>(shoppingListItems);
        
        return Ok(shoppingListDtos);
    }


}