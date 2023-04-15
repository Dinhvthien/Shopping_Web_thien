﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Shopping_Web_thien.Models;

#nullable disable

namespace Shopping_Web_thien.Migrations
{
    [DbContext(typeof(ShopDbContext))]
    partial class ShopDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Shopping_Web_thien.Models.Bill", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("Date");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("recipientAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("recipientName")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("recipientPhone")
                        .IsRequired()
                        .HasColumnType("nvarchar(500)");

                    b.HasKey("Id");

                    b.HasIndex("UserID");

                    b.ToTable("HoaDon", (string)null);
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.BillDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDHD")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("IDHD");

                    b.HasIndex("IDSP");

                    b.ToTable("HoaDonChiTiet", (string)null);
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.Cart", b =>
                {
                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(1000)
                        .IsUnicode(true)
                        .HasColumnType("nchar(1000)")
                        .IsFixedLength();

                    b.HasKey("UserID");

                    b.ToTable("GioHang", (string)null);
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.CartDetails", b =>
                {
                    b.Property<Guid>("ID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("IDSP")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<Guid>("UserID")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID");

                    b.HasIndex("IDSP");

                    b.HasIndex("UserID");

                    b.ToTable("GioHangChiTiet", (string)null);
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.Product", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("Supplier")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("avaliabaleQuantity")
                        .HasColumnType("int");

                    b.Property<string>("photo")
                        .IsRequired()
                        .HasColumnType("nvarchar(1000)");

                    b.HasKey("Id");

                    b.ToTable("SanPham", (string)null);
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.Role", b =>
                {
                    b.Property<Guid>("RoleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("RoleID");

                    b.ToTable("VaiTro", (string)null);
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.User", b =>
                {
                    b.Property<Guid>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("PassWord")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.Property<Guid>("RoleID")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("UserID");

                    b.HasIndex("RoleID");

                    b.ToTable("NguoiDung", (string)null);
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.Bill", b =>
                {
                    b.HasOne("Shopping_Web_thien.Models.User", "User")
                        .WithMany("Bills")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Bill_User");

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.BillDetails", b =>
                {
                    b.HasOne("Shopping_Web_thien.Models.Bill", "Bill")
                        .WithMany("Detail")
                        .HasForeignKey("IDHD")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopping_Web_thien.Models.Product", "Product")
                        .WithMany("Details")
                        .HasForeignKey("IDSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bill");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.Cart", b =>
                {
                    b.HasOne("Shopping_Web_thien.Models.User", "User")
                        .WithOne("Cart")
                        .HasForeignKey("Shopping_Web_thien.Models.Cart", "UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.CartDetails", b =>
                {
                    b.HasOne("Shopping_Web_thien.Models.Product", "Product")
                        .WithMany("CartDetail")
                        .HasForeignKey("IDSP")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Shopping_Web_thien.Models.Cart", "Cart")
                        .WithMany("CarDetail")
                        .HasForeignKey("UserID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cart");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.User", b =>
                {
                    b.HasOne("Shopping_Web_thien.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.Bill", b =>
                {
                    b.Navigation("Detail");
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.Cart", b =>
                {
                    b.Navigation("CarDetail");
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.Product", b =>
                {
                    b.Navigation("CartDetail");

                    b.Navigation("Details");
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("Shopping_Web_thien.Models.User", b =>
                {
                    b.Navigation("Bills");

                    b.Navigation("Cart")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}