﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Models
{
    public class Cart
    {
        public int ID { get; set; }
        public int UserID { get; set; }
        public IEnumerable<CartProducts> CartProductID { get; set; }


    }
}
