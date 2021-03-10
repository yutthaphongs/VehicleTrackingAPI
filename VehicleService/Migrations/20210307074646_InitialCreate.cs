using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VehicleService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vehicles",
                columns: table => new
                {
                    VehicleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VehicleName = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    NumberPlate = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    OwnerName = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    GpsSerialNumber = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    UpdateBy = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vehicles", x => x.VehicleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vehicles");
        }
    }
}
