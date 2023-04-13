using System.ComponentModel.DataAnnotations;

namespace EggSplorer.Models
{
    public class Users
    {
        public int ID { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public int? PhoneNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter your email")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Please enter your password")]
        public string Password { get; set; }

        public bool IsAdmin { get; set; }

        public bool IsApproved { get; set; }

        public ICollection<Orders>? Order { get; set; } = null!;
    }
}
