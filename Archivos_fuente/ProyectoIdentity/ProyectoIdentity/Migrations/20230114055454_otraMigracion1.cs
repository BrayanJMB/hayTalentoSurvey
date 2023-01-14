using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class otraMigracion1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Demograficos_Encuesta_IdEncuesta",
                table: "Demograficos");

            migrationBuilder.DropIndex(
                name: "IX_Demograficos_IdEncuesta",
                table: "Demograficos");

            migrationBuilder.DropColumn(
                name: "IdEncuesta",
                table: "Demograficos");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEncuesta",
                table: "Demograficos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Demograficos_IdEncuesta",
                table: "Demograficos",
                column: "IdEncuesta");

            migrationBuilder.AddForeignKey(
                name: "FK_Demograficos_Encuesta_IdEncuesta",
                table: "Demograficos",
                column: "IdEncuesta",
                principalTable: "Encuesta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
