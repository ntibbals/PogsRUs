using System;
using Xunit;
using PogsRUs.Models;
using System.Collections.Generic;

namespace TestSuite.ModelTests
{
    public class OrderHistoryModelTestSuite
    {
        public Product CreateProduct()
        {
            Product testProduct = new Product
            {
                ID = 1,
                Sku = "S-Red-1",
                Name = "Red Slammer",
                PogType = PogType.Slammer,
                Price = 1.00M,
                Description = "A super sick Red Slammer.",
                Image = "https://static1.milkcapmania.co.uk/Img/pogs/POG%20Kinis/300DPI/19-Red.png"
            };

            return testProduct;

        }

        public Order CreateOrder()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            List<OrderProduct> purchasedProducts = new List<OrderProduct>();

            Order testOrder = new Order("jimbob@pogs.com", DateTime.Today);
            testOrder.ID = 1;
            testOrder.TotalPrice = 1;
            testOrder.PurchasedProducts = purchasedProducts;
            return testOrder;
        }

        public OrderProduct CreateOrderProduct()
        {
            Product testProduct = CreateProduct();


            OrderProduct testOrderProduct = new OrderProduct
            (
                testProduct.ID,
                1,
                testProduct.Name,
                testProduct.Price,
                1,
                DateTime.Today
            );
            testOrderProduct.ID = 1;

            return testOrderProduct;
        }

        public OrderHistory CreateOrderHistory()
        {
            Order testOrder = CreateOrder();
            List<Order> allUserOrders = new List<Order>();

            OrderHistory testOrderHistory = new OrderHistory(testOrder.UserID);
            testOrderHistory.ID = 1;
            testOrderHistory.AllUserOrders = allUserOrders;

            return testOrderHistory;
        }

        [Fact]
        public void TestIDSet()
        {
            OrderHistory testOrderHistory = CreateOrderHistory();
            testOrderHistory.ID = 100;

            Assert.Equal(100, testOrderHistory.ID);
        }

        [Fact]
        public void TestIDGet()
        {
            OrderHistory testOrderHistory = CreateOrderHistory();
            Assert.Equal(1, testOrderHistory.ID);
        }

        [Fact]
        public void TestUserIDSet()
        {
            OrderHistory testOrderHistory = CreateOrderHistory();
            testOrderHistory.UserID = "RickyBobby@Pogs.com";

            Assert.Equal("RickyBobby@Pogs.com", testOrderHistory.UserID);

        }

        [Fact]
        public void TestUserIDGet()
        {
            OrderHistory testOrderHistory = CreateOrderHistory();

            Assert.Equal("jimbob@pogs.com", testOrderHistory.UserID);
        }

        [Fact]
        public void TestAllUserOrdersSet()
        {
            OrderHistory testOrderHistory = CreateOrderHistory();

            Order testOrder = CreateOrder();
            Order testOrderTwo = CreateOrder();
            testOrderTwo.ID = 2;

            testOrderHistory.AllUserOrders.Add(testOrderTwo);

            ICollection<Order> expected = new List<Order>();
            expected.Add(testOrderTwo);
            expected.Add(testOrder);

            ICollection<OrderProduct> actual = testOrder.PurchasedProducts;
        }

        [Fact]
        public void TestPurchasedProductsGet()
        {
            OrderHistory testOrderHistory = CreateOrderHistory();

            Order testOrder = CreateOrder();

            ICollection<Order> expected = new List<Order>();
            expected.Add(testOrder);

            ICollection<OrderProduct> actual = testOrder.PurchasedProducts;

        }
    }
}
