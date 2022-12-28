using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class aspectosdemograficos2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Country",
                column: "CountryName",
                values: new object[]
                {
                    "Antigua y Barbuda",
                    "Argentina",
                    "Bahamas",
                    "Barbados",
                    "Belice",
                    "Bolivia",
                    "Brasil",
                    "Canadá",
                    "Chile",
                    "Colombia",
                    "Costa Rica",
                    "Cuba",
                    "Dominica",
                    "Ecuador",
                    "El Salvador",
                    "Estados Unidos",
                    "Granada",
                    "Guatemala",
                    "Guyana",
                    "Haití",
                    "Honduras",
                    "Jamaica",
                    "México",
                    "Nicaragua",
                    "Panamá",
                    "Paraguay",
                    "Perú",
                    "República Dominicana",
                    "San Cristóbal y Nieves",
                    "San Vicente y las Granadinas",
                    "Santa Lucía",
                    "Surinam",
                    "Trinidad y Tobago",
                    "Uruguay",
                    "Venezuela"
                });

            migrationBuilder.InsertData(
                table: "City",
                columns: new[] { "CityName", "CountryId" },
                values: new object[,]
                {
                    { "Apartadó", "Colombia" },
                    { "Barrancabermeja", "Colombia" },
                    { "Barranquilla", "Colombia" },
                    { "Bello", "Colombia" },
                    { "Bogotá", "Colombia" },
                    { "Bucaramanga", "Colombia" },
                    { "Buenaventura", "Colombia" },
                    { "Cali", "Colombia" },
                    { "Cartagena", "Colombia" },
                    { "Cúcuta", "Colombia" },
                    { "Dosquebradas", "Colombia" },
                    { "Envigado", "Colombia" },
                    { "Florencia", "Colombia" },
                    { "Floridablanca", "Colombia" },
                    { "Girón", "Colombia" },
                    { "Ibagué", "Colombia" },
                    { "Itagüí", "Colombia" },
                    { "Maicao", "Colombia" },
                    { "Manizales", "Colombia" },
                    { "Medellín", "Colombia" },
                    { "Montería", "Colombia" },
                    { "Neiva", "Colombia" },
                    { "Palmira", "Colombia" },
                    { "Pasto", "Colombia" },
                    { "Pereira", "Colombia" },
                    { "Piedecuesta", "Colombia" },
                    { "Popayán", "Colombia" },
                    { "Riohacha", "Colombia" },
                    { "San Andrés de Tumaco", "Colombia" },
                    { "Santa Marta", "Colombia" },
                    { "Sincelejo", "Colombia" },
                    { "Soacha", "Colombia" },
                    { "Soledad", "Colombia" },
                    { "Tuluá", "Colombia" },
                    { "Tunja", "Colombia" },
                    { "Turbo", "Colombia" },
                    { "Uribia", "Colombia" },
                    { "Valledupar", "Colombia" },
                    { "Villavicencio", "Colombia" },
                    { "Yopal", "Colombia" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Apartadó");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Barrancabermeja");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Barranquilla");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Bello");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Bogotá");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Bucaramanga");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Buenaventura");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Cali");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Cartagena");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Cúcuta");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Dosquebradas");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Envigado");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Florencia");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Floridablanca");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Girón");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Ibagué");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Itagüí");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Maicao");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Manizales");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Medellín");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Montería");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Neiva");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Palmira");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Pasto");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Pereira");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Piedecuesta");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Popayán");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Riohacha");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "San Andrés de Tumaco");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Santa Marta");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Sincelejo");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Soacha");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Soledad");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Tuluá");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Tunja");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Turbo");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Uribia");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Valledupar");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Villavicencio");

            migrationBuilder.DeleteData(
                table: "City",
                keyColumn: "CityName",
                keyValue: "Yopal");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Antigua y Barbuda");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Argentina");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Bahamas");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Barbados");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Belice");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Bolivia");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Brasil");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Canadá");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Chile");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Costa Rica");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Cuba");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Dominica");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Ecuador");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "El Salvador");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Estados Unidos");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Granada");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Guatemala");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Guyana");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Haití");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Honduras");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Jamaica");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "México");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Nicaragua");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Panamá");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Paraguay");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Perú");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "República Dominicana");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "San Cristóbal y Nieves");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "San Vicente y las Granadinas");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Santa Lucía");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Surinam");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Trinidad y Tobago");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Uruguay");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Venezuela");

            migrationBuilder.DeleteData(
                table: "Country",
                keyColumn: "CountryName",
                keyValue: "Colombia");
        }
    }
}
