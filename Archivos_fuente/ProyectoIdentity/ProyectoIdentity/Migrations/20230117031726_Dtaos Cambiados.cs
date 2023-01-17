using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class DtaosCambiados : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descripcion", "NombreCategoria" },
                values: new object[] { "País, Ciudad, Unidad de Negocio, Área Diligencie la información de acuerdo con tus datos actuales", "Aspectos Demográficos" });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descripcion", "NombreCategoria" },
                values: new object[] { "Diligencia la siguiente información acorde con tu actualidad y la de tu núcleo familiar", "Datos Demográficosa" });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descripcion", "NombreCategoria" },
                values: new object[] { "Aspectos relacionados con las condiciones favorables en la relación laboral y el ambiente de trabajo.", "Beneficios de Calidad de Vida" });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Descripcion", "NombreCategoria" },
                values: new object[] { "Paquete de mejoras extralegales que complementan el salario base, pueden ser monetarias o emocionales.", "Beneficios Monetarios y No Monetarios" });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Descripcion", "NombreCategoria" },
                values: new object[] { "Paquete de mejoras extralegales que complementan el salario base, pueden ser monetarias o emocionales", "Beneficios de Desarrollo Personal" });

            migrationBuilder.InsertData(
                table: "Categoria",
                columns: new[] { "Id", "Descripcion", "NombreCategoria" },
                values: new object[,]
                {
                    { 6, "Acciones de largo plazo que apuestan por el crecimiento personal, potencializar el talento y transformar la organización", "Beneficios en Herramientas de Trabajo" },
                    { 7, "Elementos útiles para una adecuada realización de la labor", "Beneficios/Madurez" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Descripcion", "NombreCategoria" },
                values: new object[] { "Aspectos relacionados con las condiciones favorables en la relación laboral y el ambiente de trabajo.", "Beneficios de Calidad de Vida" });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Descripcion", "NombreCategoria" },
                values: new object[] { "Paquete de mejoras extralegales que complementan el salario base, pueden ser monetarias o emocionales.", "Beneficios Monetarios y No Monetarios" });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Descripcion", "NombreCategoria" },
                values: new object[] { "Paquete de mejoras extralegales que complementan el salario base, pueden ser monetarias o emocionales", "Beneficios de Desarrollo Personal" });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Descripcion", "NombreCategoria" },
                values: new object[] { "Acciones de largo plazo que apuestan por el crecimiento personal, potencializar el talento y transformar la organización", "Beneficios en Herramientas de Trabajo" });

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Descripcion", "NombreCategoria" },
                values: new object[] { "Elementos útiles para una adecuada realización de la labor", "Beneficios/Madurez" });
        }
    }
}
