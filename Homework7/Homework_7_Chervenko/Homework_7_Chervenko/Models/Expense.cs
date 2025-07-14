using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Homework_7_Chervenko.Models
{
    public class Expense
    {
        public int Id { get; set; }

        [Required]
        [ForeignKey("Category")]
        public int CategoryId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { get; set; }

        public string? Comment { get; set; }

        //додаткове поле для реалізації перегляду щомісячної статистики
        [Required]
        public DateTime Date { get; set; } = DateTime.Now;

        public Category? Category { get; set; }

    }
}
