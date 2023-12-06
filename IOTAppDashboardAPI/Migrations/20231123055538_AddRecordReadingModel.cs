using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOTAppDashboardAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddRecordReadingModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Readings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeviceId = table.Column<int>(type: "int", nullable: false),
                    Sensor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ReadingValue = table.Column<int>(type: "int", nullable: false),
                    Moment = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ReportedByAppUserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Readings", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Readings");
        }
    }
}
