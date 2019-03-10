using Microsoft.EntityFrameworkCore;
using PogsRUs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PogsRUs.Data
{
    public class PogsRUsDbContext : DbContext
    {
        public PogsRUsDbContext(DbContextOptions<PogsRUsDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //TODO: Add Seeds here

            // Product Seeds
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    ID = 1,
                    Sku = "S-Red-1",
                    Name = "Red Slammer",
                    PogType = PogType.Slammer,
                    Price = 1.00M,
                    Description = "A super sick Red Slammer.",
                    Image = "https://static1.milkcapmania.co.uk/Img/pogs/POG%20Kinis/300DPI/19-Red.png"
                },
                new Product
                {
                    ID = 2,
                    Sku = "MC-Red-2",
                    Name = "Red Milk Cap",
                    PogType = PogType.MilkCap,
                    Price = 0.50M,
                    Description = "A super sick Red Milk Cap.",
                    Image = "https://static1.milkcapmania.co.uk/Img/pogs/Canada%20Games/Casper/Kinis/300DPI/Red-07.png"
                },
                 new Product
                 {
                     ID = 3,
                     Sku = "S-Blue-3",
                     Name = "Blue Slammer",
                     PogType = PogType.Slammer,
                     Price = 1.00M,
                     Description = "A super sick Blue Slammer.",
                     Image = "http://i.ebayimg.com/00/s/MTE3N1gxMTc3/z/~TIAAOSwEetWAoU-/$_35.JPG"
                 },
                new Product
                {
                    ID = 4,
                    Sku = "MC-Blue-4",
                    Name = "Blue Milk Cap",
                    PogType = PogType.MilkCap,
                    Price = 0.50M,
                    Description = "A super sick Blue Milk Cap.",
                    Image = "https://static1.milkcapmania.co.uk/Img/pogs/POG%20Kinis/300DPI/23-Blue.png"
                },
                new Product
                {
                    ID = 5,
                    Sku = "S-Green-5",
                    Name = "Green Slammer",
                    PogType = PogType.Slammer,
                    Price = 1.00M,
                    Description = "A super sick Green Slammer.",
                    Image = "https://i.pinimg.com/originals/39/a6/66/39a666224fb6e0ce3beed353f8f63395.jpg"
                },
                new Product
                {
                    ID = 6,
                    Sku = "MC-Green-6",
                    Name = "Green Milk Cap",
                    PogType = PogType.MilkCap,
                    Price = 0.50M,
                    Description = "A super sick Green Milk Cap.",
                    Image = "https://static1.milkcapmania.co.uk/Img/pogs/The%20Tick/Kinis/300DPI/Green-Arthur.png"
                },
                new Product
                {
                    ID = 7,
                    Sku = "S-Yellow-7",
                    Name = "Yellow Slammer",
                    PogType = PogType.Slammer,
                    Price = 1.00M,
                    Description = "A super sick Yellow Slammer.",
                    Image = "https://static1.milkcapmania.co.uk/Img/Chupa%20Caps/Slammers/300DPI/Yellow.png"
                },
                new Product
                {
                    ID = 8,
                    Sku = "MC-Yellow-8",
                    Name = "Yellow Milk Cap",
                    PogType = PogType.MilkCap,
                    Price = 0.50M,
                    Description = "A super sick Yellow Milk Cap.",
                    Image = "https://static1.milkcapmania.co.uk/Img/pogs/Avimage/Power%20Rangers/300DPI/54-Yellow-Ranger-%28Gold%29.png"
                },
                new Product
                {
                    ID = 9,
                    Sku = "S-Orange-9",
                    Name = "Orange Slammer",
                    PogType = PogType.Slammer,
                    Price = 1.00M,
                    Description = "A super sick Orange Slammer.",
                    Image = "https://static1.milkcapmania.co.uk/Img/Fun%20Caps/031-060%20Aladdin/Slammers/300DPI/Lamp-orange.png"
                },
                new Product
                {
                    ID = 10,
                    Sku = "MC-Orange-10",
                    Name = "Orange Milk Cap",
                    PogType = PogType.MilkCap,
                    Price = 0.50M,
                    Description = "A super sick Orange Milk Cap.",
                    Image = "https://mightyjabba.files.wordpress.com/2010/08/jabba_pog_slammer2.jpg?w=300&h=282"
                }
                );
        }

        //TODO: Add table references here.
        public DbSet<Product> Products { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartProduct> CartProducts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProduct> OrderProducts { get; set; }
        public DbSet<OrderHistory> OrderHistories { get; set; }

    }
}
