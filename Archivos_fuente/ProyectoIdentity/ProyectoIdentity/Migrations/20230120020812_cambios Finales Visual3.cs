using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class cambiosFinalesVisual3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncuestaRepondente_Respondente_RespondenteId",
                table: "EncuestaRepondente");

            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_EncuestaRepondente_EncuestaRepondenteEncuestaId_EncuestaRepondenteRespondenteId",
                table: "Respuesta");

            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_Pregunta_EncuestaMadurez",
                table: "Respuesta");

            migrationBuilder.DropTable(
                name: "DemograficosName");

            migrationBuilder.DropIndex(
                name: "IX_Respuesta_EncuestaMadurez",
                table: "Respuesta");

            migrationBuilder.DropIndex(
                name: "IX_Respuesta_EncuestaRepondenteEncuestaId_EncuestaRepondenteRespondenteId",
                table: "Respuesta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EncuestaRepondente",
                table: "EncuestaRepondente");

            migrationBuilder.DropColumn(
                name: "EncuestaMadurez",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "EncuestaRepondenteEncuestaId",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "EncuestaRepondenteRespondenteId",
                table: "Respuesta");

            migrationBuilder.AlterColumn<Guid>(
                name: "RespondenteId",
                table: "EncuestaRepondente",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "EncuestaRepondente",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "PonderadoRespuesta",
                table: "EncuestaRepondente",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EncuestaRepondente",
                table: "EncuestaRepondente",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "DemograficoPersonal",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parentesco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EstadoCivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelEducativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DependenciaEconomica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RespondenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemograficoPersonal", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemograficoPersonal_Respondente_RespondenteId",
                        column: x => x.RespondenteId,
                        principalTable: "Respondente",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RespuestaMadurezcs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DescripcionRespuesta = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Valor = table.Column<float>(type: "real", nullable: true),
                    PreguntaId = table.Column<int>(type: "int", nullable: false),
                    EncuestaRespondenteID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RespuestaMadurezcs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RespuestaMadurezcs_EncuestaRepondente_EncuestaRespondenteID",
                        column: x => x.EncuestaRespondenteID,
                        principalTable: "EncuestaRepondente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RespuestaMadurezcs_Pregunta_PreguntaId",
                        column: x => x.PreguntaId,
                        principalTable: "Pregunta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EncuestaRepondente_EncuestaId",
                table: "EncuestaRepondente",
                column: "EncuestaId");

            migrationBuilder.CreateIndex(
                name: "IX_DemograficoPersonal_RespondenteId",
                table: "DemograficoPersonal",
                column: "RespondenteId");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaMadurezcs_EncuestaRespondenteID",
                table: "RespuestaMadurezcs",
                column: "EncuestaRespondenteID");

            migrationBuilder.CreateIndex(
                name: "IX_RespuestaMadurezcs_PreguntaId",
                table: "RespuestaMadurezcs",
                column: "PreguntaId");

            migrationBuilder.AddForeignKey(
                name: "FK_EncuestaRepondente_Respondente_RespondenteId",
                table: "EncuestaRepondente",
                column: "RespondenteId",
                principalTable: "Respondente",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_Pregunta_PreguntaId",
                table: "Respuesta",
                column: "PreguntaId",
                principalTable: "Pregunta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EncuestaRepondente_Respondente_RespondenteId",
                table: "EncuestaRepondente");

            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_Pregunta_PreguntaId",
                table: "Respuesta");

            migrationBuilder.DropTable(
                name: "DemograficoPersonal");

            migrationBuilder.DropTable(
                name: "RespuestaMadurezcs");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EncuestaRepondente",
                table: "EncuestaRepondente");

            migrationBuilder.DropIndex(
                name: "IX_EncuestaRepondente_EncuestaId",
                table: "EncuestaRepondente");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "EncuestaRepondente");

            migrationBuilder.DropColumn(
                name: "PonderadoRespuesta",
                table: "EncuestaRepondente");

            migrationBuilder.AddColumn<int>(
                name: "EncuestaMadurez",
                table: "Respuesta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EncuestaRepondenteEncuestaId",
                table: "Respuesta",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EncuestaRepondenteRespondenteId",
                table: "Respuesta",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "RespondenteId",
                table: "EncuestaRepondente",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_EncuestaRepondente",
                table: "EncuestaRepondente",
                columns: new[] { "EncuestaId", "RespondenteId" });

            migrationBuilder.CreateTable(
                name: "DemograficosName",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RespondenteId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DependenciaEconomica = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Edad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estadocivil = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NivelEducativo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Parentezco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DemograficosName", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DemograficosName_Respondente_RespondenteId",
                        column: x => x.RespondenteId,
                        principalTable: "Respondente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_EncuestaMadurez",
                table: "Respuesta",
                column: "EncuestaMadurez");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_EncuestaRepondenteEncuestaId_EncuestaRepondenteRespondenteId",
                table: "Respuesta",
                columns: new[] { "EncuestaRepondenteEncuestaId", "EncuestaRepondenteRespondenteId" });

            migrationBuilder.CreateIndex(
                name: "IX_DemograficosName_RespondenteId",
                table: "DemograficosName",
                column: "RespondenteId");

            migrationBuilder.AddForeignKey(
                name: "FK_EncuestaRepondente_Respondente_RespondenteId",
                table: "EncuestaRepondente",
                column: "RespondenteId",
                principalTable: "Respondente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_EncuestaRepondente_EncuestaRepondenteEncuestaId_EncuestaRepondenteRespondenteId",
                table: "Respuesta",
                columns: new[] { "EncuestaRepondenteEncuestaId", "EncuestaRepondenteRespondenteId" },
                principalTable: "EncuestaRepondente",
                principalColumns: new[] { "EncuestaId", "RespondenteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_Pregunta_EncuestaMadurez",
                table: "Respuesta",
                column: "EncuestaMadurez",
                principalTable: "Pregunta",
                principalColumn: "Id");
        }
    }
}
