using System;
using Xunit;
using PogsRUs.Models;

namespace TestSuite.ModelTests
{
    public class OrderTestModelSuite
    {
        public Order CreateOrder()
        {
            Order testOrder = new Order("jimbob@pogs.com", DateTime.Today);
            testOrder.ID = 1;
            return testOrder;  
        }
    }
}
