using HealthApp_Backend.Models.Dto;
using HealthApp_Backend.Repositories;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Tracks.API.Models.DTO;

namespace HealthApp_Backend.Controllers
{
    [Route("api/[controller]")]
    [EnableCors("AllowSpecificOrigin")]
    [ApiController]
    
    public class AuthController : ControllerBase
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly ITokenRepository tokenRepository;

        public AuthController(UserManager<IdentityUser> userManager, ITokenRepository tokenRepository)
        {
            this.userManager = userManager;
            this.tokenRepository = tokenRepository;
        }


        [HttpPost]
        [Route("signup")]
        public async Task<IActionResult> Register([FromBody] RegisterRequestDto registerRequestDto)
        {
            var registerRequestRolesDto = new RegisterRequestRolesDto()
            {
                Username = registerRequestDto.Username,
                Password = registerRequestDto.Password,
                Roles = ["Reader"]
            };
            
            
            var identityUser = new IdentityUser
            {
                UserName = registerRequestRolesDto.Username,
                Email = registerRequestRolesDto.Username
            };

            var identityResult = await userManager.CreateAsync(identityUser, registerRequestDto.Password);
            if (identityResult.Succeeded)
            {
                if (registerRequestRolesDto.Roles != null && registerRequestRolesDto.Roles.Any())
                {
                    identityResult = await userManager.AddToRolesAsync(identityUser, registerRequestRolesDto.Roles);

                    if (identityResult.Succeeded)

                    {
                        
                        
                        return Ok(identityResult);
                    }
                        
                }

            }
            return BadRequest("Something went wrong");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto loginRequestDto)
        {
            var user = await userManager.FindByEmailAsync(loginRequestDto.Username);
            if (user != null) 
            {
                var checkPasswordResult = await userManager.CheckPasswordAsync(user, loginRequestDto.Password);
                if (checkPasswordResult)
                {
                    var roles = await userManager.GetRolesAsync(user);
                    if (roles != null)
                    {

                        var jwtToken = tokenRepository.CreateJWTToken(user, roles.ToList());

                        var response = new LoginResponseDto
                        {
                            JwtToken = jwtToken,
                        };

                        return Ok(response);

                    }
                    
                }
            }
            return BadRequest("User/PasswordHasher incorrect");
        }
    }
}
