﻿// <auto-generated />
using System;
using DataAccessObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace DataAccessObjects.Migrations
{
    [DbContext(typeof(HmsDbContext))]
    [Migration("20241101033012_InitialCreate")]
    partial class InitialCreate
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.10")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("BusinessObjects.BookingDetail", b =>
                {
                    b.Property<int>("BookingDetailID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingDetailID"));

                    b.Property<decimal>("ActualPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("BookingReservationID")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("RoomID")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BookingDetailID");

                    b.HasIndex("BookingReservationID");

                    b.HasIndex("RoomID");

                    b.ToTable("BookingDetails");
                });

            modelBuilder.Entity("BusinessObjects.BookingReservation", b =>
                {
                    b.Property<int>("BookingReservationID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BookingReservationID"));

                    b.Property<DateTime>("BookingDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("BookingStatus")
                        .HasColumnType("int");

                    b.Property<int>("CustomerID")
                        .HasColumnType("int");

                    b.Property<decimal>("TotalPrice")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("BookingReservationID");

                    b.HasIndex("CustomerID");

                    b.ToTable("BookingReservations");
                });

            modelBuilder.Entity("BusinessObjects.Customer", b =>
                {
                    b.Property<int>("CustomerID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CustomerID"));

                    b.Property<DateTime?>("CustomerBirthday")
                        .HasColumnType("datetime2");

                    b.Property<string>("CustomerFullName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CustomerStatus")
                        .HasColumnType("int");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Telephone")
                        .IsRequired()
                        .HasMaxLength(12)
                        .HasColumnType("nvarchar(12)");

                    b.HasKey("CustomerID");

                    b.ToTable("Customers");
                });

            modelBuilder.Entity("BusinessObjects.RoomInformation", b =>
                {
                    b.Property<int>("RoomID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomID"));

                    b.Property<string>("RoomDescription")
                        .IsRequired()
                        .HasMaxLength(220)
                        .HasColumnType("nvarchar(220)");

                    b.Property<int>("RoomMaxCapacity")
                        .HasColumnType("int");

                    b.Property<string>("RoomNumber")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("RoomPricePerDate")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomStatus")
                        .HasColumnType("int");

                    b.Property<int>("RoomTypeID")
                        .HasColumnType("int");

                    b.HasKey("RoomID");

                    b.HasIndex("RoomTypeID");

                    b.ToTable("RoomInformations");
                });

            modelBuilder.Entity("BusinessObjects.RoomType", b =>
                {
                    b.Property<int>("RoomTypeID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RoomTypeID"));

                    b.Property<string>("RoomTypeName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TypeDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("TypeNote")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("RoomTypeID");

                    b.ToTable("RoomTypes");
                });

            modelBuilder.Entity("BusinessObjects.BookingDetail", b =>
                {
                    b.HasOne("BusinessObjects.BookingReservation", "BookingReservation")
                        .WithMany("BookingDetails")
                        .HasForeignKey("BookingReservationID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BusinessObjects.RoomInformation", "Room")
                        .WithMany("BookingDetails")
                        .HasForeignKey("RoomID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookingReservation");

                    b.Navigation("Room");
                });

            modelBuilder.Entity("BusinessObjects.BookingReservation", b =>
                {
                    b.HasOne("BusinessObjects.Customer", "Customer")
                        .WithMany("BookingReservations")
                        .HasForeignKey("CustomerID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Customer");
                });

            modelBuilder.Entity("BusinessObjects.RoomInformation", b =>
                {
                    b.HasOne("BusinessObjects.RoomType", "RoomType")
                        .WithMany("Rooms")
                        .HasForeignKey("RoomTypeID")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RoomType");
                });

            modelBuilder.Entity("BusinessObjects.BookingReservation", b =>
                {
                    b.Navigation("BookingDetails");
                });

            modelBuilder.Entity("BusinessObjects.Customer", b =>
                {
                    b.Navigation("BookingReservations");
                });

            modelBuilder.Entity("BusinessObjects.RoomInformation", b =>
                {
                    b.Navigation("BookingDetails");
                });

            modelBuilder.Entity("BusinessObjects.RoomType", b =>
                {
                    b.Navigation("Rooms");
                });
#pragma warning restore 612, 618
        }
    }
}
