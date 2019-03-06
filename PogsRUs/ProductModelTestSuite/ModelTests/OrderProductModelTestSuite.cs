using System;
using Xunit;
using PogsRUs.Models;

namespace TestSuite.ModelTests
{
    public class OrderProductModelTestSuite
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
            Order testOrder = new Order("jimbob@pogs.com", DateTime.Today);
            testOrder.ID = 1;
            return testOrder;
        }

        public OrderProduct CreateOrderProduct()
        {
            Product testProduct = CreateProduct();
            Order testOrder = CreateOrder();

            OrderProduct testOrderProduct = new OrderProduct
            (
                testProduct.ID,
                testOrder.ID,
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
            OrderProduct testOrderProduct = CreateOrderProduct();
            testOrderProduct.ID = 100;

            Assert.Equal(100, testOrderProduct.ID);
        }

        [Fact]
        public void TestIDGet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();

            Assert.Equal(1, testOrderProduct.ID);
        }

        [Fact]
        public void TestProductIDSet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            testOrderProduct.ProductID = 100;

            Assert.Equal(100, testOrderProduct.ProductID);
        }

        [Fact]
        public void TestProductIDGet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            Product testProduct = CreateProduct();

            Assert.Equal(testProduct.ID, testOrderProduct.ProductID);
        }

        [Fact]
        public void TestOrderIDSet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            testOrderProduct.OrderID = 100;

            Assert.Equal(100, testOrderProduct.OrderID);
        }

        [Fact]
        public void TestOrderIDGet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            Order testOrder = CreateOrder();

            Assert.Equal(testOrder.ID, testOrderProduct.OrderID);
        }

        [Fact]
        public void TestNameSet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            testOrderProduct.Name = "JimBob";

            Assert.Equal("JimBob", testOrderProduct.Name);
        }

        [Fact]
        public void TestNameGet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            Product testProduct = CreateProduct();

            Assert.Equal(testProduct.Name, testOrderProduct.Name);
        }

        [Fact]
        public void TestQuantitySet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            testOrderProduct.Quantity = 100;

            Assert.Equal(100, testOrderProduct.Quantity);
        }

        [Fact]
        public void TestQuantityGet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            Assert.Equal(1, testOrderProduct.Quantity);
        }

        [Fact]
        public void TestSingleItemPriceSet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            testOrderProduct.SingleItemPrice = 100;

            Assert.Equal(100, testOrderProduct.SingleItemPrice);
        }

        [Fact]
        public void TestSingleItemPriceGet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            Assert.Equal(1.00M, testOrderProduct.Quantity);
        }

        [Fact]
        public void TestTimeStampSet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            DateTime time = DateTime.Now;
            testOrderProduct.TimeStamp = time;

            Assert.Equal(time, testOrderProduct.TimeStamp);
        }

        [Fact]
        public void TestTimeStampGet()
        {
            OrderProduct testOrderProduct = CreateOrderProduct();
            Assert.Equal(DateTime.Today, testOrderProduct.TimeStamp);
        }

    }
}
