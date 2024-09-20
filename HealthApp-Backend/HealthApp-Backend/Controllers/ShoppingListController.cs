using HealthApp_Backend.Models.Dto;
using HealthApp_Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HealthApp_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingListController : Controller
{
    
    private readonly IShoppingListrepository iShoppingListrepository;
    
    public ShoppingListController(IShoppingListrepository iShoppingListrepository)
    {
        this.iShoppingListrepository = iShoppingListrepository;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllShoppingListItems()
    {
        var shoppingListItems = await iShoppingListrepository.GetAllShoppingListItemsAsync();

        // Map to DTOs inline
        var shoppingListDtos = shoppingListItems.Select(shoppingList => new ShoppingListReturnDto()
        {
            Id = shoppingList.Id,
            CreatedOn = shoppingList.CreatedOn,
            UserId = shoppingList.UserId,
            KcalGoal = shoppingList.KcalGoal,
            ProteinGoal = shoppingList.proteinGoal,
            KcalMax = shoppingList.kcalMax,
            ProteinCurrent = shoppingList.proteinCurrent,
            KcalCurrent = shoppingList.kcalCurrent,
            ShoppingListFoodItems = shoppingList.ShoppingListFoodItems.Select(slf => new ShoppingListFoodItemDto
            {
                Id = slf.Id,
                // ShoppingListId = slf.ShoppingListId,
                // FoodItemId = slf.FoodItemId,
                FoodItem = new FoodItemDto
                {
                    Id = slf.FoodItem.Id,
                    Name = slf.FoodItem.name,
                    KcalAmount = slf.FoodItem.kcalAmount,
                    ProteinAmount = slf.FoodItem.proteinAmount,
                    Measurement = slf.FoodItem.measurement
                }
            }).ToList()
        }).ToList();

        return Ok(shoppingListDtos);
    }


}