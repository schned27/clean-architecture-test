using System.ComponentModel.DataAnnotations;

namespace MUIManagement.Infrastructure.Database.Entities.Requests
{
    public class UserRegistrationRequest
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
