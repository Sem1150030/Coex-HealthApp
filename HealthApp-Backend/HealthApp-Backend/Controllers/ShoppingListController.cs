using System.Security.Claims;
using AutoMapper;
using HealthApp_Backend.Models.DomainModels;
using HealthApp_Backend.Models.Dto;
using HealthApp_Backend.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;

namespace HealthApp_Backend.Controllers;


    //Dev Only[ApiController]
              [Authorize]
              [EnableCors("AllowSpecificOrigin")]
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
        var foodItem = await foodItemRepository.GetFoodItemByIdAsync(shoppingListFoodItemRequestDto.FoodItemId, userId);
        Guid shoppingListId = shoppingList.Id;
        
        var shoppingListFoodItem = new ShoppingListFoodItem
        {
            Id = Guid.NewGuid(), 
            ShoppingListId = shoppingListId,
            FoodItemId = shoppingListFoodItemRequestDto.FoodItemId
        };

        await iShoppingListrepository.AddItemToShoppingListAsync(shoppingListFoodItem, todaysDate);
        var currentKcal = shoppingList.kcalCurrent;
        var currentProtein = shoppingList.proteinCurrent;
        
        
        var newKcal = currentKcal + foodItem.kcalAmount;
        var newProtein = currentProtein + foodItem.proteinAmount;
        var newFat = shoppingList.fatCurrent + foodItem.fatAmount;
        var newCarb = shoppingList.carbCurrent + foodItem.carbAmount;
        
        var itemsChanged = await iShoppingListrepository.updateShoppingListAsync(newKcal, newProtein, newFat, newCarb ,userId, todaysDate);
        if (itemsChanged == null)
        {
            return NotFound("Something went wrong edditing the shopping list");
        }

        
        return Ok("Added item to shopping list");
    }


    
    [HttpDelete]
    [Route("DeleteItem/{id:Guid}/{foodItemId:Guid}")]
    public async Task<IActionResult> DeleteItemFromShoppingList(Guid id, Guid foodItemId)
    {
        var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        if (userIdString == null)
        {
            return NotFound("User not found");
        }
        var shoppingList = await iShoppingListrepository.GetShoppingListByUIDAndDateAsync(Guid.Parse(userIdString), DateTime.Now.Date);
        var foodItem = await foodItemRepository.GetFoodItemByIdAsync(foodItemId, Guid.Parse(userIdString));
        
        var newKcal = shoppingList.kcalCurrent - foodItem.kcalAmount;
        var newProtein = shoppingList.proteinCurrent - foodItem.proteinAmount;
        var newFat = shoppingList.fatCurrent - foodItem.fatAmount;
        var newCarb = shoppingList.carbCurrent - foodItem.carbAmount;
        var result = await iShoppingListrepository.deleteItemFromShoppingListAsync(id);
        if(result == null)
        {
            return NotFound("Item not found");
        }
        
        var itemsChanged = await iShoppingListrepository.updateShoppingListAsync(newKcal, newProtein, newFat,newCarb ,Guid.Parse(userIdString), DateTime.Now.Date);
        if (itemsChanged == null)
        {
            return NotFound("Something went wrong edditing the shopping list");
        }
        
        
        
        return Ok("Item deleted from shopping list");
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