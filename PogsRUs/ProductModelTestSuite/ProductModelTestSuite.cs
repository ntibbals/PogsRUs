using System;
using Xunit;
using PogsRUs.Models;

namespace ProductModelTestSuite
{
    public class ProductModelTestSuite
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


        [Fact]
        public void TestIDSet()
        {

        }
    }
}
