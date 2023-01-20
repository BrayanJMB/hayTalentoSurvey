using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class ChangeDatabase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "CityId",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "CountryId",
                table: "Respondente");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Respondente",
                newName: "BusinessUnitNameBusinnes");

            migrationBuilder.RenameIndex(
                name: "IX_Respondente_AreaId",
                table: "Respondente",
                newName: "IX_Respondente_BusinessUnitNameBusinnes");

            migrationBuilder.AlterColumn<string>(
                name: "BussinesUnitId",
                table: "Respondente",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Respondente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "AreaName",
                table: "Respondente",
                type: "nvarchar(450)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "Respondente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "Respondente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5,
                column: "Descripcion",
                value: "Acciones de largo plazo que apuestan por el crecimiento personal, potencializar el talento y transformar la organización.");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descripcion",
                value: "Elementos útiles para una adecuada realización de la labor.");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 7,
                column: "Descripcion",
                value: "Nivel en el que la compañía asimila o integra buenas prácticas relacionadas con la administración de los beneficios");

            migrationBuilder.CreateIndex(
                name: "IX_Respondente_AreaName",
                table: "Respondente",
                column: "AreaName");

            migrationBuilder.AddForeignKey(
                name: "FK_Respondente_Area_AreaName",
                table: "Respondente",
                column: "AreaName",
                principalTable: "Area",
                principalColumn: "AreaName");

            migrationBuilder.AddForeignKey(
                name: "FK_Respondente_BusinessUnit_BusinessUnitNameBusinnes",
                table: "Respondente",
                column: "BusinessUnitNameBusinnes",
                principalTable: "BusinessUnit",
                principalColumn: "NameBusinnes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respondente_Area_AreaName",
                table: "Respondente");

            migrationBuilder.DropForeignKey(
                name: "FK_Respondente_BusinessUnit_BusinessUnitNameBusinnes",
                table: "Respondente");

            migrationBuilder.DropIndex(
                name: "IX_Respondente_AreaName",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "Area",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "AreaName",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "City",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "Respondente");

            migrationBuilder.RenameColumn(
                name: "BusinessUnitNameBusinnes",
                table: "Respondente",
                newName: "AreaId");

            migrationBuilder.RenameIndex(
                name: "IX_Respondente_BusinessUnitNameBusinnes",
                table: "Respondente",
                newName: "IX_Respondente_AreaId");

            migrationBuilder.AlterColumn<string>(
                name: "BussinesUnitId",
                table: "Respondente",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5,
                column: "Descripcion",
                value: "“Acciones de largo plazo que apuestan por el crecimiento personal, potencializar el talento y transformar la organización”.");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descripcion",
                value: "“Elementos útiles para una adecuada realización de la labor”.");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 7,
                column: "Descripcion",
                value: "“Nivel en el que la compañía asimila o integra buenas prácticas relacionadas con la administración de los\r\nbeneficios”");

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
    }
}
