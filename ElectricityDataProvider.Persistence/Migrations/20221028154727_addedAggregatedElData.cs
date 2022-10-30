using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ElectricityDataProvider.Persistence.Migrations
{
    public partial class addedAggregatedElData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ElectricityDatas");

            migrationBuilder.CreateTable(
                name: "AggregatedElDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PPlus = table.Column<double>(type: "float", nullable: true),
                    PMinus = table.Column<double>(type: "float", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AggregatedElDatas", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AggregatedElDatas");

            migrationBuilder.CreateTable(
                name: "ElectricityDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    PMinus = table.Column<double>(type: "float", nullable: false),
                    PPlus = table.Column<double>(type: "float", nullable: false),
                    Region = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Time = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ElectricityDatas", x => x.Id);
                });
        }
    }
}
