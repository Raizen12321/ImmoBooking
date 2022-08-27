using System.ComponentModel.DataAnnotations;

namespace ImmoBooking.Models
{
    public class ShoppingCartItem
    {
        [Key]

        public int Id { get; set; }

        public Property Property { get; set; }

        public int AmountofDays { get; set; }

        public string ShoppingCartId { get; set; }


    }
}
