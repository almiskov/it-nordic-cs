﻿// <auto-generated />
using System;
using Lesson_34_Classwork.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Lesson_34_Classwork.Migrations
{
    [DbContext(typeof(OnlineStoreContext))]
    partial class OnlineStoreContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.2.4-servicing-10062")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Lesson_34_Classwork.Domain.Customer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnName("Name")
                        .HasColumnType("VARCHAR(50)");

                    b.HasKey("Id");

                    b.HasAlternateKey("Name")
                        .HasName("UQ_Customers_Name");

                    b.ToTable("Customer","dbo");
                });

            modelBuilder.Entity("Lesson_34_Classwork.Domain.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CustomerId");

                    b.Property<decimal>("Discount");

                    b.Property<DateTimeOffset>("OrderDate");

                    b.HasKey("Id");

                    b.HasIndex("CustomerId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Lesson_34_Classwork.Domain.OrderItem", b =>
                {
                    b.Property<int?>("OrderId");

                    b.Property<int?>("ProductId");

                    b.Property<int>("NumberOfItems");

                    b.Property<int?>("OrderId1");

                    b.HasKey("OrderId", "ProductId")
                        .HasName("Pk_OrderItems");

                    b.HasIndex("OrderId1");

                    b.HasIndex("ProductId");

                    b.ToTable("OrderItems");
                });

            modelBuilder.Entity("Lesson_34_Classwork.Domain.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Lesson_34_Classwork.Domain.Order", b =>
                {
                    b.HasOne("Lesson_34_Classwork.Domain.Customer", "Customer")
                        .WithMany()
                        .HasForeignKey("CustomerId");
                });

            modelBuilder.Entity("Lesson_34_Classwork.Domain.OrderItem", b =>
                {
                    b.HasOne("Lesson_34_Classwork.Domain.Order")
                        .WithMany("OrderItems")
                        .HasForeignKey("OrderId1");

                    b.HasOne("Lesson_34_Classwork.Domain.Product", "Product")
                        .WithMany()
                        .HasForeignKey("ProductId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}