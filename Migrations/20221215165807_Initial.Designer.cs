﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Vodovoz.DbContexts;

#nullable disable

namespace Vodovoz.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20221215165807_Initial")]
    partial class Initial
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "7.0.0");

            modelBuilder.Entity("Vodovoz.DTOs.DepartmentDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<int>("StaffMemberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Vodovoz.DTOs.OrderDTO", b =>
                {
                    b.Property<int>("Id")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProductId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Count")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ProductName")
                        .HasColumnType("TEXT");

                    b.Property<int>("StaffMemberId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id", "ProductId");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("Vodovoz.DTOs.ProductDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Price")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Products");
                });

            modelBuilder.Entity("Vodovoz.DTOs.StaffMemberDTO", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Birthday")
                        .HasColumnType("TEXT");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gender")
                        .HasColumnType("INTEGER");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("SurName")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("StaffMembers");
                });
#pragma warning restore 612, 618
        }
    }
}