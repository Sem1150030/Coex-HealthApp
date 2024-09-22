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
    
    [HttpGet]
    public async Task<IActionResult> GetAllShoppingListItems()
    {
        var shoppingListItems = await iShoppingListrepository.GetAllShoppingListItemsAsync();

        
        var shoppingListDtos = mapper.Map<List<ShoppingListReturnDto>>(shoppingListItems);
        
        return Ok(shoppingListDtos);
    }
    
    [HttpGet]
    [Route("{id:Guid}")]
    public async Task<IActionResult> GetShoppingListPerId(Guid id)
    {
        var shoppingListItems = await iShoppingListrepository.GetShoppingListPerId(id);

        
        var shoppingListDtos = mapper.Map<ShoppingListReturnDto>(shoppingListItems);
        
        return Ok(shoppingListDtos);
    }
    
    [HttpPost]
    [Route("AddItem")]
    public async Task<IActionResult> AddItemToShoppingList([FromBody] ShoppingListFoodItemRequestDto shoppingListFoodItemRequestDto)
    {
        var sLFId = mapper.Map<ShoppingListFoodItem>(shoppingListFoodItemRequestDto);
        
        var shoppingListFoodItem = new ShoppingListFoodItem
        {
            Id = Guid.NewGuid(),  // Generate a new unique Id
            ShoppingListId = shoppingListFoodItemRequestDto.ShoppingListId,
            FoodItemId = shoppingListFoodItemRequestDto.FoodItemId
        };

        await iShoppingListrepository.AddItemToShoppingListAsync(shoppingListFoodItem);
        return Ok("Added item to shopping list");
    }


}