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
    [Migration("20210925160048_addedDbContexts")]
    partial class addedDbContexts
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 63)
                .HasAnnotation("ProductVersion", "5.0.10")
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            modelBuilder.Entity("PavluqueOrderGenerator.Model.Product", b =>
                {
                    b.Property<string>("SKU")
                        .HasColumnType("text");

                    b.Property<string>("Name")
                        .HasColumnType("text");

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
