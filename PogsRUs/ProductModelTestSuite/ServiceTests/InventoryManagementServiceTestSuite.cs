using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PogsRUs.Data;
using PogsRUs.Models;
using PogsRUs.Models.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.InMemory;
using Xunit;
using Microsoft.EntityFrameworkCore.Design;
using System.Threading.Tasks;

namespace TestSuite.ServiceTests
{
    public class InventoryManagementServiceTestSuite
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
        public async void CanCreateProduct()
        {
            DbContextOptions<PogsRUsDbContext> options = new DbContextOptionsBuilder<PogsRUsDbContext>().UseInMemoryDatabase("CreateProduct").Options;

            using (PogsRUsDbContext context = new PogsRUsDbContext(options))
            {
                Product testProduct = CreateProduct();

                InventoryManagementService inventoryService = new InventoryManagementService(context);

                await inventoryService.SaveAsync(testProduct);

                Product result = context.Products.FirstOrDefault(p => p.ID == testProduct.ID);

                Assert.Equal(testProduct, result);
            }
        }

        [Fact]
        public async void CanDeleteProduct()
        {
            DbContextOptions<PogsRUsDbContext> options = new DbContextOptionsBuilder<PogsRUsDbContext>().UseInMemoryDatabase("DeleteProduct").Options;

            using (PogsRUsDbContext context = new PogsRUsDbContext(options))
            {
                Product testProduct = CreateProduct();

                InventoryManagementService inventoryService = new InventoryManagementService(context);

                await inventoryService.SaveAsync(testProduct);

                await inventoryService.DeleteProduct(testProduct);

                Product result = context.Products.FirstOrDefault(p => p.ID == testProduct.ID);

                Assert.Null(result);
            }
        }

        [Fact]
        public async void CanGetProduct()
        {
            DbContextOptions<PogsRUsDbContext> options = new DbContextOptionsBuilder<PogsRUsDbContext>().UseInMemoryDatabase("GetProduct").Options;

            using (PogsRUsDbContext context = new PogsRUsDbContext(options))
            {
                Product testProduct = CreateProduct();

                InventoryManagementService inventoryService = new InventoryManagementService(context);

                await inventoryService.SaveAsync(testProduct);

                Product expected = context.Products.FirstOrDefault(p => p.ID == testProduct.ID);

                Product actual = await inventoryService.GetProduct(testProduct.ID);

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async void CanGetProducts()
        {
            DbContextOptions<PogsRUsDbContext> options = new DbContextOptionsBuilder<PogsRUsDbContext>().UseInMemoryDatabase("GetProducts").Options;

            using (PogsRUsDbContext context = new PogsRUsDbContext(options))
            {
                Product testProductOne = CreateProduct();

                Product testProductTwo = new Product() { ID = 2, Description = "Im a pog.", Image = "www.image.com", Name = "Dope Pog", PogType = PogType.MilkCap, Price = 3, Sku = "Im a SKU" };

                InventoryManagementService inventoryService = new InventoryManagementService(context);

                await inventoryService.SaveAsync(testProductOne);
                await inventoryService.SaveAsync(testProductTwo);

                IEnumerable<Product> expected = new List<Product> { testProductOne, testProductTwo };
                IEnumerable<Product> actual = await inventoryService.GetProducts();

                Assert.Equal(expected, actual);
            }
        }

        [Fact]
        public async void CanUpdateProduct()
        {
            DbContextOptions<PogsRUsDbContext> options = new DbContextOptionsBuilder<PogsRUsDbContext>().UseInMemoryDatabase("UpdateProduct").Options;

            using (PogsRUsDbContext context = new PogsRUsDbContext(options))
            {
                Product testProduct = CreateProduct();

                InventoryManagementService inventoryService = new InventoryManagementService(context);

                await inventoryService.SaveAsync(testProduct);

                testProduct.Name = "New Name";

                await inventoryService.SaveAsync(testProduct);

                Product result = context.Products.FirstOrDefault(p => p.ID == testProduct.ID);

                Assert.Equal(testProduct, result);
            }
        }
    }
}
