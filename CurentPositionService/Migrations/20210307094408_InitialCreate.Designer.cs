﻿// <auto-generated />
using System;
using CurentPositionService.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace CurentPositionService.Migrations
{
    [DbContext(typeof(CurentPositionContext))]
    [Migration("20210307094408_InitialCreate")]
    partial class InitialCreate
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("CurentPositionService.Models.CurentPosition", b =>
                {
                    b.Property<int>("CurentPositionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<DateTime>("CurentDate")
                        .HasColumnType("datetime");

                    b.Property<decimal>("Fuel")
                        .HasColumnType("decimal(12,4)");

                    b.Property<string>("GpsSerialNumber")
                        .HasColumnType("nvarchar(60)");

                    b.Property<decimal>("Latitude")
                        .HasColumnType("decimal(9,6)");

                    b.Property<decimal>("Longitude")
                        .HasColumnType("decimal(9,6)");

                    b.Property<decimal>("Speed")
                        .HasColumnType("decimal(12,4)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.HasKey("CurentPositionId");

                    b.ToTable("CurentPositions");
                });
#pragma warning restore 612, 618
        }
    }
}
