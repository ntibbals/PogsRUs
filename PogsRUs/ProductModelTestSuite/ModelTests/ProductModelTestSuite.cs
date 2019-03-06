using System;
using Xunit;
using PogsRUs.Models;

namespace TestSuite.ModelTests
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
            Product testProduct = new Product();
            testProduct.ID = 1;
            Assert.Equal(1, testProduct.ID);
        }

        [Fact]
        public void TestIDGet()
        {
            Product testProduct = CreateProduct();
            Assert.Equal(1, testProduct.ID);
        }

        [Fact]
        public void TestSkuSet()
        {
            Product testProduct = new Product();
            testProduct.Sku = "S-Red-1";
            Assert.Equal("S-Red-1", testProduct.Sku);
        }

        [Fact]
        public void TestSkuGet()
        {
            Product testProduct = CreateProduct();
            Assert.Equal("S-Red-1", testProduct.Sku);
        }

        [Fact]
        public void TestNameSet()
        {
            Product testProduct = new Product();
            testProduct.Name = "Red Slammer";
            Assert.Equal("Red Slammer", testProduct.Name);
        }

        [Fact]
        public void TestNameGet()
        {
            Product testProduct = CreateProduct();
            Assert.Equal("Red Slammer", testProduct.Name);
        }

        [Fact]
        public void TestPogTypeSet()
        {
            Product testProduct = new Product();
            testProduct.PogType = PogType.Slammer;
            Assert.Equal(PogType.Slammer, testProduct.PogType);
        }

        [Fact]
        public void TestPogTypeGet()
        {
            Product testProduct = CreateProduct();
            Assert.Equal(PogType.Slammer, testProduct.PogType);
        }

        [Fact]
        public void TestPriceSet()
        {
            Product testProduct = new Product();
            testProduct.Price = 1.00M;
            Assert.Equal(1.00M, testProduct.Price);
        }

        [Fact]
        public void TestPriceGet()
        {
            Product testProduct = CreateProduct();
            Assert.Equal(1.00M, testProduct.Price);
        }

        [Fact]
        public void TestDescriptionSet()
        {
            Product testProduct = new Product();
            testProduct.Description = "A super sick Red Slammer.";
            Assert.Equal("A super sick Red Slammer.", testProduct.Description);
        }

        [Fact]
        public void TestDescriptionGet()
        {
            Product testProduct = CreateProduct();
            Assert.Equal("A super sick Red Slammer.", testProduct.Description);
        }

        [Fact]
        public void TestImageSet()
        {
            Product testProduct = new Product();
            testProduct.Image = "https://static1.milkcapmania.co.uk/Img/pogs/POG%20Kinis/300DPI/19-Red.png";
            Assert.Equal("https://static1.milkcapmania.co.uk/Img/pogs/POG%20Kinis/300DPI/19-Red.png", testProduct.Image);
        }

        [Fact]
        public void TestImageGet()
        {
            Product testProduct = CreateProduct();
            Assert.Equal("https://static1.milkcapmania.co.uk/Img/pogs/POG%20Kinis/300DPI/19-Red.png", testProduct.Image);
        }
    }
}
