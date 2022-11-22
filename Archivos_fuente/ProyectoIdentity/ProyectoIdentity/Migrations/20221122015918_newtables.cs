using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class newtables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Area",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "Ciudad",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "DependienteEconomicamente",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "Edad",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "EstadoCivil",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "NivelEducativo",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "Nombre",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "Parentesco",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "Sexo",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "UnidadNegocio",
                table: "Respondente");

            migrationBuilder.DropColumn(
                name: "VersionId",
                table: "Respondente");

            migrationBuilder.AddColumn<float>(
                name: "Valor",
                table: "Respuesta",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.CreateTable(
                name: "Demograficos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Demograficos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EncuestaDemografico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdEncuesta = table.Column<int>(type: "int", nullable: false),
                    IdDemografico = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaDemografico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestaDemografico_Demograficos_IdDemografico",
                        column: x => x.IdDemografico,
                        principalTable: "Demograficos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaDemografico_Encuesta_IdEncuesta",
                        column: x => x.IdEncuesta,
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OpcionesDemo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DemograficoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OpcionesDemo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OpcionesDemo_Demograficos_DemograficoId",
                        column: x => x.DemograficoId,
                        principalTable: "Demograficos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RespondenteDemografico",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespondenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DemograficoId = table.Column<int>(type: "int", nullable: false),
                    DemograficosId = table.Column<int>(type: "int", nullable: true),
                    Respuesta = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespondenteDemografico", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespondenteDemografico_Demograficos_DemograficosId",
                        column: x => x.DemograficosId,
                        principalTable: "Demograficos",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RespondenteDemografico_Respondente_RespondenteId",
                        column: x => x.RespondenteId,
                        principalTable: "Respondente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaDemografico_IdDemografico",
                table: "EncuestaDemografico",
                column: "IdDemografico");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaDemografico_IdEncuesta",
                table: "EncuestaDemografico",
                column: "IdEncuesta");

            migrationBuilder.CreateIndex(
                name: "IX_OpcionesDemo_DemograficoId",
                table: "OpcionesDemo",
                column: "DemograficoId");

            migrationBuilder.CreateIndex(
                name: "IX_RespondenteDemografico_DemograficosId",
                table: "RespondenteDemografico",
                column: "DemograficosId");

            migrationBuilder.CreateIndex(
                name: "IX_RespondenteDemografico_RespondenteId",
                table: "RespondenteDemografico",
                column: "RespondenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncuestaDemografico");

            migrationBuilder.DropTable(
                name: "OpcionesDemo");

            migrationBuilder.DropTable(
                name: "RespondenteDemografico");

            migrationBuilder.DropTable(
                name: "Demograficos");

            migrationBuilder.DropColumn(
                name: "Valor",
                table: "Respuesta");

            migrationBuilder.AddColumn<string>(
                name: "Area",
                table: "Respondente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ciudad",
                table: "Respondente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DependienteEconomicamente",
                table: "Respondente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Edad",
                table: "Respondente",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EstadoCivil",
                table: "Respondente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NivelEducativo",
                table: "Respondente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Nombre",
                table: "Respondente",
                type: "nvarchar(250)",
                maxLength: 250,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Parentesco",
                table: "Respondente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sexo",
                table: "Respondente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UnidadNegocio",
                table: "Respondente",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "VersionId",
                table: "Respondente",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
