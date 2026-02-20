using System.ComponentModel.DataAnnotations;

namespace Pinkleaf_Collection.Models
{
    
    public class RegisterViewModel
    {
        [Required]
        public string FullName { get; set; }

        public string Address { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public string Phone { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }
    }
    }
