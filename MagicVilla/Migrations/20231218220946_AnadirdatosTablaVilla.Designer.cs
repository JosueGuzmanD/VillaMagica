﻿// <auto-generated />
using System;
using MagicVilla.Datos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MagicVilla.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20231218220946_AnadirdatosTablaVilla")]
    partial class AnadirdatosTablaVilla
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("MagicVilla.Models.Villa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Amenidad")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Details")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagenUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Ocuppants")
                        .HasColumnType("int");

                    b.Property<double>("Price")
                        .HasColumnType("float");

                    b.Property<int>("SquareMeters")
                        .HasColumnType("int");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("VillaName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Villas");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Amenidad = "",
                            CreationDate = new DateTime(2023, 12, 18, 23, 9, 45, 253, DateTimeKind.Local).AddTicks(7301),
                            Details = "",
                            ImagenUrl = "",
                            Ocuppants = 5,
                            Price = 200.0,
                            SquareMeters = 50,
                            UpdateDate = new DateTime(2023, 12, 18, 23, 9, 45, 253, DateTimeKind.Local).AddTicks(7346),
                            VillaName = "Villa real"
                        },
                        new
                        {
                            Id = 2,
                            Amenidad = "",
                            CreationDate = new DateTime(2023, 12, 18, 23, 9, 45, 253, DateTimeKind.Local).AddTicks(7349),
                            Details = "Detalle de la vista",
                            ImagenUrl = "",
                            Ocuppants = 6,
                            Price = 230.0,
                            SquareMeters = 70,
                            UpdateDate = new DateTime(2023, 12, 18, 23, 9, 45, 253, DateTimeKind.Local).AddTicks(7351),
                            VillaName = "Villa con vista a la playa"
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
