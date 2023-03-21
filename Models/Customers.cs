using System.ComponentModel.DataAnnotations;

namespace EggSplorer.Models
{
    public class Customers
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Please enter your first name")]
        public string? FirstName { get; set; }

        [Required(ErrorMessage = "Please enter your last name")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "Please enter your phone number")]
        public int? PhoneNumber { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Please enter your email")]
        public string? Email { get; set; }

        public ICollection<Orders> Order { get; set; } = null!;
    }
}
