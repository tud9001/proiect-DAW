using System.ComponentModel.DataAnnotations;

namespace WebApi.Models.Users
{
    public class AuthenticateRequest
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Password { get; set; }
    }
}