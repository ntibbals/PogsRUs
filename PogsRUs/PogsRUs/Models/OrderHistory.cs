using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class OrderHistory
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public ICollection<Order> AllUserOrders { get; set; }

        public OrderHistory(string userID)
        {
            UserID = UserID;
        }
    }
}
