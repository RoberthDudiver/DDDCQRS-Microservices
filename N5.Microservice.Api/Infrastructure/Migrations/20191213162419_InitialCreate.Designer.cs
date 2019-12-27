﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using DDDCQRS.Microservice.Infrastructure;

namespace DDDCQRS.Microservice.Api.Infrastructure.Migrations
{
    [DbContext(typeof(ProductsContext))]
    [Migration("20191213162419_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("DDDCQRS.Microservice.Domain.AggregatesModel.InventoryAggregate.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("_categoryId")
                        .HasColumnName("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<DateTime>("_date")
                        .HasColumnName("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("_stock")
                        .HasColumnName("Stock")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_categoryId");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("_description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ProductCategory");
                });

            modelBuilder.Entity("DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("_categoryId")
                        .HasColumnName("ProductCategoryId")
                        .HasColumnType("int");

                    b.Property<string>("_description")
                        .IsRequired()
                        .HasColumnName("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("_name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("_price")
                        .HasColumnName("Price")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("_categoryId");

                    b.ToTable("Product");
                });

            modelBuilder.Entity("DDDCQRS.Microservice.Domain.AggregatesModel.InventoryAggregate.Inventory", b =>
                {
                    b.HasOne("DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate.Category", null)
                        .WithMany()
                        .HasForeignKey("_categoryId");
                });

            modelBuilder.Entity("DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate.Product", b =>
                {
                    b.HasOne("DDDCQRS.Microservice.Domain.AggregatesModel.ProductAggregate.Category", null)
                        .WithMany()
                        .HasForeignKey("_categoryId");
                });
#pragma warning restore 612, 618
        }
    }
}