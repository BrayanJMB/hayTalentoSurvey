using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class Countries : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: "Aspectos relacionados con las condiciones favorables en la relación laboral y el ambiente de trabajo.");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descripcion",
                value: "Paquete de mejoras extralegales que complementan el salario base, pueden ser monetarias o emocionales.");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3,
                column: "Descripcion",
                value: "Paquete de mejoras extralegales que complementan el salario base, pueden ser monetarias o emocionales");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descripcion",
                value: "Acciones de largo plazo que apuestan por el crecimiento personal, potencializar el talento y transformar la organización");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5,
                column: "Descripcion",
                value: "Elementos útiles para una adecuada realización de la labor");

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityName", "CountryId" },
                values: new object[,]
                {
                    { "Basseterre", "San Cristóbal y Nieves" },
                    { "Belmopán", "Belice" },
                    { "Brasilia", "Brasil" },
                    { "Bridgetown", "Barbados" },
                    { "Buenos Aires", "Argentina" },
                    { "Caracas", "Venezuela" },
                    { "Ciudad de Guatemala", "Guatemala" },
                    { "Ciudad de México", "México" },
                    { "Ciudad de Panamá", "Panamá" },
                    { "Georgetown", "Guyana" },
                    { "Granada", "Granada" },
                    { "Kingston", "Jamaica" },
                    { "La Habana", "Cuba" },
                    { "Lima", "Perú" },
                    { "Managua", "Nicaragua" },
                    { "Montevideo", "Uruguay" },
                    { "Nasáu", "Bahamas" },
                    { "Ottawa", "Canadá" },
                    { "Paraguay", "Paraguay" },
                    { "Puerto Príncipe", "Haití" },
                    { "Quito", "Ecuador" },
                    { "Roseau", "Dominica" },
                    { "Saint John", "Antigua y Barbuda" },
                    { "San José", "Costa Rica" },
                    { "San Salvador", "El Salvador" },
                    { "Santiago", "Chile" },
                    { "Santo Domingo", "República Dominicana" },
                    { "Sucre", "Bolivia" },
                    { "Tegucigalpa", "Honduras" },
                    { "Washington", "Estados Unidos" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Basseterre");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Belmopán");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Brasilia");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Bridgetown");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Buenos Aires");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Caracas");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Ciudad de Guatemala");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Ciudad de México");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Ciudad de Panamá");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Georgetown");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Granada");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Kingston");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "La Habana");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Lima");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Managua");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Montevideo");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Nasáu");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Ottawa");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Paraguay");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Puerto Príncipe");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Quito");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Roseau");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Saint John");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "San José");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "San Salvador");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Santiago");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Santo Domingo");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Sucre");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Tegucigalpa");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Washington");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 3,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descripcion",
                value: null);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5,
                column: "Descripcion",
                value: null);
        }
    }
}
