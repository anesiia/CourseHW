using System.ComponentModel.DataAnnotations;

namespace Homework_5_Chervenko.Models
{
    internal class Order
    {
        [Key]
        public int ord_id { get; set; }
        public DateTime ord_datetime { get; set; }
        public int ord_an { get; set; }
    }
}
