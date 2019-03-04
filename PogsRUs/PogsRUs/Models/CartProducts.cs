using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class CartProduct
    {

        public int ID { get; set; }
        public int ProductID { get; set; }
        public int CartID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal SingleItemPrice { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return SingleItemPrice * Quantity;
            }
        }

        public CartProduct(int productID, int cartID, string name, decimal singleItemPrice)
        {
            ProductID = productID;
            CartID = cartID;
            Quantity = 1;
            Name = name;
            SingleItemPrice = singleItemPrice;
        }
    }
}
