using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GPSRecordService.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "GPSRecords",
                columns: table => new
                {
                    GPSRecordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GpsSerialNumber = table.Column<string>(type: "nvarchar(60)", nullable: true),
                    Latitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Longitude = table.Column<decimal>(type: "decimal(9,6)", nullable: false),
                    Fuel = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    Speed = table.Column<decimal>(type: "decimal(12,4)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreateBy = table.Column<string>(type: "nvarchar(60)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GPSRecords", x => x.GPSRecordId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GPSRecords");
        }
    }
}
