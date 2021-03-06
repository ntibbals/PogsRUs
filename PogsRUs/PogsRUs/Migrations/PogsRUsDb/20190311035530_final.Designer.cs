﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PogsRUs.Data;

namespace PogsRUs.Migrations.PogsRUsDb
{
    [DbContext(typeof(PogsRUsDbContext))]
    [Migration("20190311035530_final")]
    partial class final
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.2-servicing-10034")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("PogsRUs.Models.Cart", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<decimal>("TotalPrice");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.ToTable("Carts");
                });

            modelBuilder.Entity("PogsRUs.Models.CartProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CartID");

                    b.Property<string>("Name");

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("SingleItemPrice");

                    b.HasKey("ID");

                    b.HasIndex("CartID");

                    b.ToTable("CartProducts");
                });

            modelBuilder.Entity("PogsRUs.Models.Order", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CustName");

                    b.Property<int?>("OrderHistoryID");

                    b.Property<DateTime>("TimeStamp");

                    b.Property<decimal>("TotalPrice");

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.HasIndex("OrderHistoryID");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("PogsRUs.Models.OrderHistory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("UserID");

                    b.HasKey("ID");

                    b.ToTable("OrderHistories");
                });

            modelBuilder.Entity("PogsRUs.Models.OrderProduct", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<int>("OrderID");

                    b.Property<int>("ProductID");

                    b.Property<int>("Quantity");

                    b.Property<decimal>("SingleItemPrice");

                    b.Property<DateTime>("TimeStamp");

                    b.HasKey("ID");

                    b.HasIndex("OrderID");

                    b.ToTable("OrderProducts");
                });

            modelBuilder.Entity("PogsRUs.Models.Product", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<string>("Image")
                        .IsRequired();

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("PogType");

                    b.Property<decimal>("Price");

                    b.Property<string>("Sku")
                        .IsRequired();

                    b.HasKey("ID");

                    b.ToTable("Products");

                    b.HasData(
                        new
                        {
                            ID = 1,
                            Description = "A super sick Red Slammer.",
                            Image = "https://static1.milkcapmania.co.uk/Img/pogs/POG%20Kinis/300DPI/19-Red.png",
                            Name = "Red Slammer",
                            PogType = 0,
                            Price = 1.00m,
                            Sku = "S-Red-1"
                        },
                        new
                        {
                            ID = 2,
                            Description = "A super sick Red Milk Cap.",
                            Image = "https://static1.milkcapmania.co.uk/Img/pogs/Canada%20Games/Casper/Kinis/300DPI/Red-07.png",
                            Name = "Red Milk Cap",
                            PogType = 1,
                            Price = 0.50m,
                            Sku = "MC-Red-2"
                        },
                        new
                        {
                            ID = 3,
                            Description = "A super sick Blue Slammer.",
                            Image = "http://i.ebayimg.com/00/s/MTE3N1gxMTc3/z/~TIAAOSwEetWAoU-/$_35.JPG",
                            Name = "Blue Slammer",
                            PogType = 0,
                            Price = 1.00m,
                            Sku = "S-Blue-3"
                        },
                        new
                        {
                            ID = 4,
                            Description = "A super sick Blue Milk Cap.",
                            Image = "https://static1.milkcapmania.co.uk/Img/pogs/POG%20Kinis/300DPI/23-Blue.png",
                            Name = "Blue Milk Cap",
                            PogType = 1,
                            Price = 0.50m,
                            Sku = "MC-Blue-4"
                        },
                        new
                        {
                            ID = 5,
                            Description = "A super sick Green Slammer.",
                            Image = "https://i.pinimg.com/originals/39/a6/66/39a666224fb6e0ce3beed353f8f63395.jpg",
                            Name = "Green Slammer",
                            PogType = 0,
                            Price = 1.00m,
                            Sku = "S-Green-5"
                        },
                        new
                        {
                            ID = 6,
                            Description = "A super sick Green Milk Cap.",
                            Image = "https://static1.milkcapmania.co.uk/Img/pogs/The%20Tick/Kinis/300DPI/Green-Arthur.png",
                            Name = "Green Milk Cap",
                            PogType = 1,
                            Price = 0.50m,
                            Sku = "MC-Green-6"
                        },
                        new
                        {
                            ID = 7,
                            Description = "A super sick Yellow Slammer.",
                            Image = "https://static1.milkcapmania.co.uk/Img/Chupa%20Caps/Slammers/300DPI/Yellow.png",
                            Name = "Yellow Slammer",
                            PogType = 0,
                            Price = 1.00m,
                            Sku = "S-Yellow-7"
                        },
                        new
                        {
                            ID = 8,
                            Description = "A super sick Yellow Milk Cap.",
                            Image = "https://static1.milkcapmania.co.uk/Img/pogs/Avimage/Power%20Rangers/300DPI/54-Yellow-Ranger-%28Gold%29.png",
                            Name = "Yellow Milk Cap",
                            PogType = 1,
                            Price = 0.50m,
                            Sku = "MC-Yellow-8"
                        },
                        new
                        {
                            ID = 9,
                            Description = "A super sick Orange Slammer.",
                            Image = "https://static1.milkcapmania.co.uk/Img/Fun%20Caps/031-060%20Aladdin/Slammers/300DPI/Lamp-orange.png",
                            Name = "Orange Slammer",
                            PogType = 0,
                            Price = 1.00m,
                            Sku = "S-Orange-9"
                        },
                        new
                        {
                            ID = 10,
                            Description = "A super sick Orange Milk Cap.",
                            Image = "https://mightyjabba.files.wordpress.com/2010/08/jabba_pog_slammer2.jpg?w=300&h=282",
                            Name = "Orange Milk Cap",
                            PogType = 1,
                            Price = 0.50m,
                            Sku = "MC-Orange-10"
                        });
                });

            modelBuilder.Entity("PogsRUs.Models.CartProduct", b =>
                {
                    b.HasOne("PogsRUs.Models.Cart")
                        .WithMany("CartProducts")
                        .HasForeignKey("CartID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("PogsRUs.Models.Order", b =>
                {
                    b.HasOne("PogsRUs.Models.OrderHistory")
                        .WithMany("AllUserOrders")
                        .HasForeignKey("OrderHistoryID");
                });

            modelBuilder.Entity("PogsRUs.Models.OrderProduct", b =>
                {
                    b.HasOne("PogsRUs.Models.Order")
                        .WithMany("PurchasedProducts")
                        .HasForeignKey("OrderID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
