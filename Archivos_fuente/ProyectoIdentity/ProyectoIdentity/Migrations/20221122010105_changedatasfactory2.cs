using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class changedatasfactory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pregunta_TipoPreguntaId",
                table: "Pregunta");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_TipoPreguntaId",
                table: "Pregunta",
                column: "TipoPreguntaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Pregunta_TipoPreguntaId",
                table: "Pregunta");

            migrationBuilder.CreateIndex(
                name: "IX_Pregunta_TipoPreguntaId",
                table: "Pregunta",
                column: "TipoPreguntaId",
                unique: true);
        }
    }
}
