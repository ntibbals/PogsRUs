using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class TransactionHistory
    {
        public int ID { get; set; }
        public string UserID { get; set; }
        public IEnumerable<TransactionHistoryProduct> PurchasedProducts { get; set; }
        public decimal TotalPrice { get; set; }

        public TransactionHistory(string userID)
        {
            UserID = userID;
        }
    }
}
