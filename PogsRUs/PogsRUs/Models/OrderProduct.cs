using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class OrderProduct
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int OrderID { get; set; }
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal SingleItemPrice { get; set; }
        public DateTime TimeStamp { get; set; }

        public decimal TotalPrice
        {
            get
            {
                return SingleItemPrice * Quantity;
            }
        }

        public OrderProduct(int productID, int orderID, string name, decimal singleItemPrice, int quantity, DateTime timeStamp)
        {
            ProductID = productID;
            OrderID = orderID;
            Quantity = quantity;
            Name = name;
            SingleItemPrice = singleItemPrice;
            TimeStamp = timeStamp;
        }
    }
}
