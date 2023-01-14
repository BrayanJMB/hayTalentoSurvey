using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class AddDemographic5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Link",
                table: "Encuesta",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Link",
                table: "Encuesta");
        }
    }
}
