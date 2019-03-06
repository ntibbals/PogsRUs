using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class Order
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public ICollection<OrderProduct> PurchasedProducts { get; set; }
        public decimal TotalPrice { get; set; }
        public DateTime TimeStamp { get; set; }

        public Order(string userID, DateTime timeStamp)
        {
            UserID = userID;
            TimeStamp = timeStamp;
        }
    }
}
