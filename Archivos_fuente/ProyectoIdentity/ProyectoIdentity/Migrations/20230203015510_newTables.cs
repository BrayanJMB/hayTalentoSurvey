using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class newTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "EncuestaRespondenteId",
                table: "Respuesta",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "EncuestaRespondenteB",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaId = table.Column<int>(type: "int", nullable: false),
                    RespondenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaRespondenteB", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EncuestaRespondenteB_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaRespondenteB_Respondente_RespondenteId",
                        column: x => x.RespondenteId,
                        principalTable: "Respondente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RespuestaPersonalizada",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    IdPregunta = table.Column<int>(type: "int", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Beneficio = table.Column<bool>(type: "bit", nullable: false),
                    Atractivo = table.Column<float>(type: "real", nullable: false),
                    Funcionamiento = table.Column<float>(type: "real", nullable: false),
                    EncuestaResponcenteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaPersonalizada", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestaPersonalizada_EncuestaRespondenteB_EncuestaResponcenteId",
                        column: x => x.EncuestaResponcenteId,
                        principalTable: "EncuestaRespondenteB",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_EncuestaRespondenteId",
                table: "Respuesta",
                column: "EncuestaRespondenteId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRespondenteB_EncuestaId",
                table: "EncuestaRespondenteB",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRespondenteB_RespondenteId",
                table: "EncuestaRespondenteB",
                column: "RespondenteId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaPersonalizada_EncuestaResponcenteId",
                table: "RespuestaPersonalizada",
                column: "EncuestaResponcenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_EncuestaRespondenteB_EncuestaRespondenteId",
                table: "Respuesta",
                column: "EncuestaRespondenteId",
                principalTable: "EncuestaRespondenteB",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_EncuestaRespondenteB_EncuestaRespondenteId",
                table: "Respuesta");

            migrationBuilder.DropTable(
                name: "RespuestaPersonalizada");

            migrationBuilder.DropTable(
                name: "EncuestaRespondenteB");

            migrationBuilder.DropIndex(
                name: "IX_Respuesta_EncuestaRespondenteId",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "EncuestaRespondenteId",
                table: "Respuesta");
        }
    }
}
