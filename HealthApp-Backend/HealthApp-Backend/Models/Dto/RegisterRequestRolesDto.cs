using System.ComponentModel.DataAnnotations;

namespace Tracks.API.Models.DTO
{
    public class RegisterRequestRolesDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Username { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public string[] Roles { get; set; }
    }
}