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
[Route("/[controller]")]

public class WeightController : Controller
{
        
        private readonly IMapper mapper;
        private readonly IWeightRepository weightTrackerRepository;
    
        public WeightController(IMapper mapper, IWeightRepository weightTrackerRepository)
        {
            this.mapper = mapper;
            this.weightTrackerRepository = weightTrackerRepository;
            
        }

        [HttpGet]
        public async Task<IActionResult> GetWeightData()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdString == null)
            {
                return NotFound("User not found");
            }
            
            var weightData = await weightTrackerRepository.getWeightDataAsync(Guid.Parse(userIdString));
            return Ok(weightData);
        }

        [HttpGet]
        [Route("/WeightToday")]
        public async Task<IActionResult> GetWeightDataToday()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (userIdString == null)
            {
                return NotFound("User not found");
            }
            
            var weightData = await weightTrackerRepository.getWeightDataTodayAsync(Guid.Parse(userIdString), DateTime.Now.Date);
            return Ok(weightData);
        }
}