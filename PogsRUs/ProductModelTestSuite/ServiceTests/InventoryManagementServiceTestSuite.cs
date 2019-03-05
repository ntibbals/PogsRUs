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

namespace TestSuite
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
            DbContextOptions<PogsRUsDbContext> options = new DbContextOptionsBuilder<PogsRUsDbContext>().UseInMemoryDatabase("XXXX").Options;
        }

        [Fact]
        public async void CanDeleteProduct()
        {
            DbContextOptions<PogsRUsDbContext> options = new DbContextOptionsBuilder<PogsRUsDbContext>().UseInMemoryDatabase("XXXX").Options;
        }

        [Fact]
        public async void CanGetProduct()
        {
            DbContextOptions<PogsRUsDbContext> options = new DbContextOptionsBuilder<PogsRUsDbContext>().UseInMemoryDatabase("XXXX").Options;
        }

        [Fact]
        public async void CanGetProducts()
        {
            DbContextOptions<PogsRUsDbContext> options = new DbContextOptionsBuilder<PogsRUsDbContext>().UseInMemoryDatabase("XXXX").Options;
        }

        [Fact]
        public async void CanUpdateProduct()
        {
            DbContextOptions<PogsRUsDbContext> options = new DbContextOptionsBuilder<PogsRUsDbContext>().UseInMemoryDatabase("XXXX").Options;
        }
    }
}
