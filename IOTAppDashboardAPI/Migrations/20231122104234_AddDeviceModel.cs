using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace IOTAppDashboardAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddDeviceModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Devices",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parameter1 = table.Column<int>(type: "int", nullable: false),
                    Parameter2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parameter3 = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Devices", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Devices");
        }
    }
}
