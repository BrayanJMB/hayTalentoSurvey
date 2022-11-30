using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class tree : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Descripcion", "NombreCategoria" },
                values: new object[,]
                {
                    { 1, null, "Beneficios de Calidad de Vida" },
                    { 2, null, "Beneficios Monetarios y No Monetarios" },
                    { 3, null, "Beneficios de Desarrollo Personal" },
                    { 4, null, "Beneficios en Herramientas de Trabajo" },
                    { 5, null, "Beneficios/Madurez" }
                });

            migrationBuilder.InsertData(
                table: "TipoPregunta",
                columns: new[] { "Id", "Descripcion", "NombreTipoPregunta" },
                values: new object[,]
                {
                    { 1, null, "Respuesta Unica" },
                    { 2, null, "Likkert" },
                    { 3, null, "Seleccion Multiple" },
                    { 4, null, "Valoracion Multiple" },
                    { 5, null, "Abierta" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "TipoPregunta",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "TipoPregunta",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "TipoPregunta",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "TipoPregunta",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "TipoPregunta",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
