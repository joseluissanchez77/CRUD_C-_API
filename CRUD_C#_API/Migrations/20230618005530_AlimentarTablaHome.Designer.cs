﻿// <auto-generated />
using System;
using CRUD_C__API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace CRUD_C__API.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20230618005530_AlimentarTablaHome")]
    partial class AlimentarTablaHome
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CRUD_C__API.Models.Home", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Occupants")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<double>("SquareMeters")
                        .HasColumnType("float");

                    b.Property<DateTime>("UpdatedDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Homes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenity = "",
                            CreatedDate = new DateTime(2023, 6, 17, 19, 55, 30, 666, DateTimeKind.Local).AddTicks(8489),
                            Description = "Conjunto residencial",
                            ImageUrl = "",
                            Name = "Villas club",
                            Occupants = 2,
                            Price = 200.0,
                            SquareMeters = 30.0,
                            UpdatedDate = new DateTime(2023, 6, 17, 19, 55, 30, 666, DateTimeKind.Local).AddTicks(8529)
                        },
                        new
                        {
                            Id = 2,
                            Amenity = "",
                            CreatedDate = new DateTime(2023, 6, 17, 19, 55, 30, 666, DateTimeKind.Local).AddTicks(8532),
                            Description = "Conjunto residencial",
                            ImageUrl = "",
                            Name = "Villas españa",
                            Occupants = 2,
                            Price = 300.0,
                            SquareMeters = 50.0,
                            UpdatedDate = new DateTime(2023, 6, 17, 19, 55, 30, 666, DateTimeKind.Local).AddTicks(8533)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}