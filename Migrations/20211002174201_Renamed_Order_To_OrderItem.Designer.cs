﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using PavluqueOrderGenerator;

namespace PavluqueOrderGenerator.Migrations
{
    [DbContext(typeof(PavluqueContext))]
    [Migration("20211002174201_Renamed_Order_To_OrderItem")]
    partial class Renamed_Order_To_OrderItem
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("OrderItemSavedOrder", b =>
                {
                    b.Property<string>("OrdersSku")
                        .HasColumnType("text");

                    b.Property<int>("SavedOrdersId")
                        .HasColumnType("integer");

                    b.HasKey("OrdersSku", "SavedOrdersId");

                    b.HasIndex("SavedOrdersId");

                    b.ToTable("OrderItemSavedOrder");
                });

            modelBuilder.Entity("PavluqueOrderGenerator.Model.OrderItem", b =>
                {
                    b.Property<string>("Sku")
                        .HasColumnType("text");

                    b.Property<int>("Quantity")
                        .HasColumnType("integer");

                    b.Property<string>("Size")
                        .HasColumnType("text");

                    b.Property<string>("Type")
                        .HasColumnType("text");

                    b.HasKey("Sku");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("PavluqueOrderGenerator.Model.Product", b =>
                {
                    b.Property<string>("SKU")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

                    b.Property<double>("Price")
                        .HasColumnType("double precision");

                    b.Property<string>("PrintId")
                        .HasColumnType("text");

                    b.Property<string[]>("Sizes")
                        .HasColumnType("text[]");

                    b.Property<string>("TypeId")
                        .HasColumnType("text");

                    b.HasKey("SKU");

                    b.HasIndex("PrintId");

                    b.HasIndex("TypeId");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("PavluqueOrderGenerator.Model.ProductPrint", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<string>("SkuCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductPrints");
                });

            modelBuilder.Entity("PavluqueOrderGenerator.Model.ProductType", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("text");

                    b.Property<bool>("Child")
                        .HasColumnType("boolean");

                    b.Property<bool>("Male")
                        .HasColumnType("boolean");

                    b.Property<string>("SkuCode")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("ProductTypes");
                });

            modelBuilder.Entity("PavluqueOrderGenerator.Model.SavedOrder", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("integer")
                        .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

                    b.Property<DateTime>("DateCreated")
                        .HasColumnType("timestamp without time zone");

                    b.Property<DateTime>("LastEdited")
                        .HasColumnType("timestamp without time zone");

                    b.HasKey("Id");

                    b.ToTable("SavedOrders");
                });

            modelBuilder.Entity("OrderItemSavedOrder", b =>
                {
                    b.HasOne("PavluqueOrderGenerator.Model.OrderItem", null)
                        .WithMany()
                        .HasForeignKey("OrdersSku")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("PavluqueOrderGenerator.Model.SavedOrder", null)
                        .WithMany()
                        .HasForeignKey("SavedOrdersId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PavluqueOrderGenerator.Model.Product", b =>
                {
                    b.HasOne("PavluqueOrderGenerator.Model.ProductPrint", "Print")
                        .WithMany("Products")
                        .HasForeignKey("PrintId");

                    b.HasOne("PavluqueOrderGenerator.Model.ProductType", "Type")
                        .WithMany("Products")
                        .HasForeignKey("TypeId");

                    b.Navigation("Print");

                    b.Navigation("Type");
                });

            modelBuilder.Entity("PavluqueOrderGenerator.Model.ProductPrint", b =>
                {
                    b.Navigation("Products");
                });

            modelBuilder.Entity("PavluqueOrderGenerator.Model.ProductType", b =>
                {
                    b.Navigation("Products");
                });
#pragma warning restore 612, 618
        }
    }
}