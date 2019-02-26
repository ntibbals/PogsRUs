using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class Cart
    {

        public int UserID { get; set; }
        public Dictionary<Product, int> CartProducts { get; set; }

        public Cart(int userID)
        {
            UserID = userID;
           Dictionary<Product, int> CartProducts = new Dictionary<Product, int>();
        }
    }
}
