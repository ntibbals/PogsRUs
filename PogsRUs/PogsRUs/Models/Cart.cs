using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public ICollection<CartProduct> CartProducts { get; set; }
        public decimal TotalPrice { get; set; }

        public Cart(string userID)
        {
            UserID = userID;
        }


    }
}
