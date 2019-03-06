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
            
        }

        [Fact]
        public void TestIDGet()
        {

        }

        [Fact]
        public void TestProductIDSet()
        {

        }

        [Fact]
        public void TestProductIDGet()
        {

        }

        [Fact]
        public void TestOrderIDSet()
        {

        }

        [Fact]
        public void TestOrderIDGet()
        {

        }

        [Fact]
        public void TestNameSet()
        {

        }

        [Fact]
        public void TestNameGet()
        {

        }

        [Fact]
        public void TestQuantitySet()
        {

        }

        [Fact]
        public void TestQuantityGet()
        {

        }

        [Fact]
        public void TestSingleItemPriceSet()
        {

        }

        [Fact]
        public void TestSingleItemPriceGet()
        {

        }

        [Fact]
        public void TestTimeStampSet()
        {

        }

        [Fact]
        public void TestTimeStampGet()
        {

        }

    }
}
