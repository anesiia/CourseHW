using System.ComponentModel.DataAnnotations;

namespace Homework_7_Chervenko.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        public List<Expense> Expenses { get; set; } = new();
    }
}
