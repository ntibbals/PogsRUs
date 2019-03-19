using System;
using Xunit;
using PogsRUs.Models;
using System.Collections.Generic;

namespace TestSuite.ModelTests
{
    public class OrderModelTestSuite
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

            Order testOrder = new Order("jimbob@pogs.com", DateTime.Today, "JimBob");
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

        [Fact]
        public void TestIDSet()
        {
            Order testOrder = CreateOrder();
            testOrder.ID = 100;

            Assert.Equal(100, testOrder.ID);           
        }

        [Fact]
        public void TestIDGet()
        {
            Order testOrder = CreateOrder();
            Assert.Equal(1, testOrder.ID);
        }

        [Fact]
        public void TestUserIDSet()
        {
            Order testOrder = CreateOrder();
            testOrder.UserID = "RickyBobby@Pogs.com";

            Assert.Equal("RickyBobby@Pogs.com", testOrder.UserID);

        }

        [Fact]
        public void TestUserIDGet()
        {
            Order testOrder = CreateOrder();
           
            Assert.Equal("jimbob@pogs.com", testOrder.UserID);
        }

        [Fact]
        public void TestPurchasedProductsSet()
        {
            Order testOrder = CreateOrder();

            OrderProduct testOrderProduct = CreateOrderProduct();
            OrderProduct testOrderProductTwo = CreateOrderProduct();
            testOrderProductTwo.ID = 2;

            testOrder.PurchasedProducts.Add(testOrderProductTwo);

            ICollection<OrderProduct> expected = new List<OrderProduct>();           
            expected.Add(testOrderProductTwo);
            expected.Add(testOrderProduct);

            ICollection<OrderProduct> actual = testOrder.PurchasedProducts;
        }

        [Fact]
        public void TestPurchasedProductsGet()
        {
            Order testOrder = CreateOrder();
            OrderProduct testOrderProduct = CreateOrderProduct();

            ICollection<OrderProduct> expected = new List<OrderProduct>();
            expected.Add(testOrderProduct);

            ICollection<OrderProduct> actual = testOrder.PurchasedProducts;
           
        }

        [Fact]
        public void TestTotalPriceSet()
        {
            Order testOrder = CreateOrder();
            testOrder.TotalPrice = 100;

            Assert.Equal(100, testOrder.TotalPrice);
        }

        [Fact]
        public void TestTotalPriceGet()
        {
            Order testOrder = CreateOrder();

            Assert.Equal(1, testOrder.TotalPrice);
        }

        [Fact]
        public void TestTimeStampSet()
        {
            Order testOrder = CreateOrder();
            DateTime time = DateTime.Now;
            testOrder.TimeStamp = time;

            Assert.Equal(time, testOrder.TimeStamp);
        }

        [Fact]
        public void TestTimeStampGet()
        {
            Order testOrder = CreateOrder();

            Assert.Equal(DateTime.Today, testOrder.TimeStamp);
        }
    }
}
