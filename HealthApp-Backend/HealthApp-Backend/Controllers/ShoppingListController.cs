using AutoMapper;
using HealthApp_Backend.Models.Dto;
using HealthApp_Backend.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HealthApp_Backend.Controllers;

[ApiController]
[Route("[controller]")]
public class ShoppingListController : Controller
{
    
    private readonly IShoppingListrepository iShoppingListrepository;
    private readonly IMapper mapper;
    
    public ShoppingListController(IShoppingListrepository iShoppingListrepository, IMapper mapper)
    {
        this.iShoppingListrepository = iShoppingListrepository;
        this.mapper = mapper;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetAllShoppingListItems()
    {
        var shoppingListItems = await iShoppingListrepository.GetAllShoppingListItemsAsync();

        // Map to DTOs inline
        var shoppingListDtos = mapper.Map<List<ShoppingListReturnDto>>(shoppingListItems);
        
        return Ok(shoppingListDtos);
    }


}