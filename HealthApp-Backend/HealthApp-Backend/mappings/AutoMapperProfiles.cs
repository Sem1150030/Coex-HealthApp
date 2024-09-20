using AutoMapper;
using HealthApp_Backend.Models.DomainModels;
using HealthApp_Backend.Models.Dto;

namespace HealthApp_Backend.mappings;

public class AutoMapperProfiles: Profile
{
    public AutoMapperProfiles()
    {
        CreateMap<ShoppingList, ShoppingListReturnDto>().ReverseMap();
        CreateMap<ShoppingListFoodItem, ShoppingListFoodItemDto>().ReverseMap(); 
        CreateMap<FoodItem, FoodItemDto>().ReverseMap();
        CreateMap<FoodItem, FoodItemReturnDto>().ReverseMap();
        CreateMap<FoodItem, CreateFoodItemMappingDto>().ReverseMap();
        CreateMap<ShoppingListFoodItemRequestDto, ShoppingListFoodItem>().ReverseMap();

    }
}