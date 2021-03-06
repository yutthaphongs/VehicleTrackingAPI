// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using VehicleService.Models;

namespace VehicleService.Migrations
{
    [DbContext(typeof(VehicleContext))]
    partial class VehicleContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.3")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("VehicleService.Models.Vehicle", b =>
                {
                    b.Property<int>("VehicleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Active")
                        .HasColumnType("bit");

                    b.Property<string>("CreateBy")
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("GpsSerialNumber")
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("NumberPlate")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("OwnerName")
                        .HasColumnType("nvarchar(60)");

                    b.Property<string>("UpdateBy")
                        .HasColumnType("nvarchar(60)");

                    b.Property<DateTime>("UpdateDate")
                        .HasColumnType("datetime");

                    b.Property<string>("VehicleName")
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("VehicleId");

                    b.ToTable("Vehicles");
                });
#pragma warning restore 612, 618
        }
    }
}
