using System.ComponentModel.DataAnnotations;

namespace WebMVC.Models
{
    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string Username { get; set; }

    }
}

