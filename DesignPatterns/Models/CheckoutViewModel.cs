using DesignPatterns.Models;
using System.Collections.Generic;
using System.Linq;

namespace DesignPatterns.Models
{
    public class CheckoutViewModel
    {
        public List<CartItem> CartItems { get; set; } = new List<CartItem>();

        public decimal GrandTotal => CartItems.Sum(x => x.Price * x.Quantity);

        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

    }
}