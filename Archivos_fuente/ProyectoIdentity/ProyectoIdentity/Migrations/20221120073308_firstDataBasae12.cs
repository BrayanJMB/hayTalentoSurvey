using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class firstDataBasae12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respondente_VersionEncuesta_VersionId",
                table: "Respondente");

            migrationBuilder.DropTable(
                name: "FechaRespuesta");

            migrationBuilder.DropTable(
                name: "VersionEncuesta");

            migrationBuilder.DropIndex(
                name: "IX_Respondente_VersionId",
                table: "Respondente");

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaDeCreacion",
                table: "Encuesta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "FechaMaximoPlazo",
                table: "Encuesta",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateTable(
                name: "EncuestaRepondente",
                columns: table => new
                {
                    EncuestaId = table.Column<int>(type: "int", nullable: false),
                    RespondenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaRespuesta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EncuestaRepondente", x => new { x.EncuestaId, x.RespondenteId });
                    table.ForeignKey(
                        name: "FK_EncuestaRepondente_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EncuestaRepondente_Respondente_RespondenteId",
                        column: x => x.RespondenteId,
                        principalTable: "Respondente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRepondente_RespondenteId",
                table: "EncuestaRepondente",
                column: "RespondenteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EncuestaRepondente");

            migrationBuilder.DropColumn(
                name: "FechaDeCreacion",
                table: "Encuesta");

            migrationBuilder.DropColumn(
                name: "FechaMaximoPlazo",
                table: "Encuesta");

            migrationBuilder.CreateTable(
                name: "FechaRespuesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespondenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FechaDeRespuesta = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FechaRespuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FechaRespuesta_Respondente_RespondenteId",
                        column: x => x.RespondenteId,
                        principalTable: "Respondente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "VersionEncuesta",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EncuestaId = table.Column<int>(type: "int", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaMaximoPlazo = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VersionNumber = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VersionEncuesta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VersionEncuesta_Encuesta_EncuestaId",
                        column: x => x.EncuestaId,
                        principalTable: "Encuesta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respondente_VersionId",
                table: "Respondente",
                column: "VersionId");

            migrationBuilder.CreateIndex(
                name: "IX_FechaRespuesta_RespondenteId",
                table: "FechaRespuesta",
                column: "RespondenteId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_VersionEncuesta_EncuestaId",
                table: "VersionEncuesta",
                column: "EncuestaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Respondente_VersionEncuesta_VersionId",
                table: "Respondente",
                column: "VersionId",
                principalTable: "VersionEncuesta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
