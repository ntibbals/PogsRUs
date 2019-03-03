﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class TransactionHistoryProduct
    {
        public int ID { get; set; }
        public int ProductID { get; set; }
        public int CartID { get; set; }
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

        public TransactionHistoryProduct(int productID, int cartID, string name, decimal price, int quantity)
        {
            ProductID = productID;
            CartID = cartID;
            Quantity = quantity;
            Name = name;
            SingleItemPrice = price;
        }
    }
}
