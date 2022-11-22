using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class changedatasfactory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categoria_Encuesta_EncuestaId",
                table: "Categoria");

            migrationBuilder.DropIndex(
                name: "IX_Categoria_EncuestaId",
                table: "Categoria");

            migrationBuilder.DropColumn(
                name: "EncuestaId",
                table: "Categoria");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaCategoria_CategoriaId",
                table: "EncuestaCategoria",
                column: "CategoriaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EncuestaCategoria_Categoria_CategoriaId",
                table: "EncuestaCategoria",
                column: "CategoriaId",
                principalTable: "Categoria",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EncuestaCategoria_Encuesta_EncuestaId",
                table: "EncuestaCategoria",
                column: "EncuestaId",
                principalTable: "Encuesta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncuestaCategoria_Categoria_CategoriaId",
                table: "EncuestaCategoria");

            migrationBuilder.DropForeignKey(
                name: "FK_EncuestaCategoria_Encuesta_EncuestaId",
                table: "EncuestaCategoria");

            migrationBuilder.DropIndex(
                name: "IX_EncuestaCategoria_CategoriaId",
                table: "EncuestaCategoria");

            migrationBuilder.AddColumn<int>(
                name: "EncuestaId",
                table: "Categoria",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Categoria_EncuestaId",
                table: "Categoria",
                column: "EncuestaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categoria_Encuesta_EncuestaId",
                table: "Categoria",
                column: "EncuestaId",
                principalTable: "Encuesta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
