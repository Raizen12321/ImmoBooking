using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ImmoBooking.Models
{
    public class OrderItem
    {
        [Key]

        public int Id { get; set; }

        public int AmountofDays { get; set; }

        public double Price { get; set; }

        public int PropertyId { get; set; }
        [ForeignKey("PropertyId")]
        public Property Property { get; set; }
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public Order Order { get; set; }
    }
}
