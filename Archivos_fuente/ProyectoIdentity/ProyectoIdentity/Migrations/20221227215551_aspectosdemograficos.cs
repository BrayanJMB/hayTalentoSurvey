using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class aspectosdemograficos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "AreaId",
                table: "Respondente",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "BussinesUnitId",
                table: "Respondente",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CityId",
                table: "Respondente",
                type: "nvarchar(255)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CountryId",
                table: "Respondente",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Area",
                columns: table => new
                {
                    AreaName = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Area", x => x.AreaName);
                });

            migrationBuilder.CreateTable(
                name: "BusinessUnit",
                columns: table => new
                {
                    NameBusinnes = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BusinessUnit", x => x.NameBusinnes);
                });

            migrationBuilder.CreateTable(
                name: "Country",
                columns: table => new
                {
                    CountryName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Country", x => x.CountryName);
                });

            migrationBuilder.CreateTable(
                name: "City",
                columns: table => new
                {
                    CityName = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CountryId = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_City", x => x.CityName);
                    table.ForeignKey(
                        name: "FK_City_Country_CountryId",
                        column: x => x.CountryId,
                        principalTable: "Country",
                        principalColumn: "CountryName");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respondente_AreaId",
                table: "Respondente",
                column: "AreaId");

            migrationBuilder.CreateIndex(
                name: "IX_Respondente_BussinesUnitId",
                table: "Respondente",
                column: "BussinesUnitId");

            migrationBuilder.CreateIndex(
                name: "IX_Respondente_CityId",
                table: "Respondente",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Respondente_CountryId",
                table: "Respondente",
                column: "CountryId");

            migrationBuilder.CreateIndex(
                name: "IX_City_CountryId",
                table: "City",
                column: "CountryId");

            migrationBuilder.AddForeignKey(
                name: "FK_Respondente_Area_AreaId",
                table: "Respondente",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "AreaName");

            migrationBuilder.AddForeignKey(
                name: "FK_Respondente_BusinessUnit_BussinesUnitId",
                table: "Respondente",
                column: "BussinesUnitId",
                principalTable: "BusinessUnit",
                principalColumn: "NameBusinnes");

            migrationBuilder.AddForeignKey(
                name: "FK_Respondente_City_CityId",
                table: "Respondente",
                column: "CityId",
                principalTable: "City",
                principalColumn: "CityName");

            migrationBuilder.AddForeignKey(
                name: "FK_Respondente_Country_CountryId",
                table: "Respondente",
                column: "CountryId",
                principalTable: "Country",
                principalColumn: "CountryName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respondente_Area_AreaId",
                table: "Respondente");

            migrationBuilder.DropForeignKey(
                name: "FK_Respondente_BusinessUnit_BussinesUnitId",
                table: "Respondente");

            migrationBuilder.DropForeignKey(
                name: "FK_Respondente_City_CityId",
                table: "Respondente");

            migrationBuilder.DropForeignKey(
                name: "FK_Respondente_Country_CountryId",
                table: "Respondente");

            migrationBuilder.DropTable(
                name: "Area");

            migrationBuilder.DropTable(
                name: "BusinessUnit");

            migrationBuilder.DropTable(
                name: "City");

            migrationBuilder.DropTable(
                name: "Country");

            migrationBuilder.DropIndex(
                name: "IX_Respondente_AreaId",
                table: "Respondente");

            migrationBuilder.DropIndex(
                name: "IX_Respondente_BussinesUnitId",
                table: "Respondente");

            migrationBuilder.DropIndex(
                name: "IX_Respondente_CityId",
                table: "Respondente");

            migrationBuilder.DropIndex(
                name: "IX_Respondente_CountryId",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "AreaId",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "BussinesUnitId",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "CityId",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Respondente");
        }
    }
}
