using System.ComponentModel.DataAnnotations;

namespace Homework_4_Chervenko.Models
{
    public class Developer
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;
    }
}
