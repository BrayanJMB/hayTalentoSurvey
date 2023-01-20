using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class cambiosFinalesVisual : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_Pregunta_PreguntaId",
                table: "Respuesta");

            migrationBuilder.AlterColumn<float>(
                name: "Valor",
                table: "Respuesta",
                type: "real",
                nullable: true,
                oldClrType: typeof(float),
                oldType: "real");

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

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: "Diligencie la información de acuerdo con tus datos actuales");

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
                name: "IX_Respuesta_EncuestaMadurez",
                table: "Respuesta",
                column: "EncuestaMadurez");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_EncuestaRepondenteEncuestaId_EncuestaRepondenteRespondenteId",
                table: "Respuesta",
                columns: new[] { "EncuestaRepondenteEncuestaId", "EncuestaRepondenteRespondenteId" });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_EncuestaRepondente_EncuestaRepondenteEncuestaId_EncuestaRepondenteRespondenteId",
                table: "Respuesta");

            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_Pregunta_EncuestaMadurez",
                table: "Respuesta");

            migrationBuilder.DropIndex(
                name: "IX_Respuesta_EncuestaMadurez",
                table: "Respuesta");

            migrationBuilder.DropIndex(
                name: "IX_Respuesta_EncuestaRepondenteEncuestaId_EncuestaRepondenteRespondenteId",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "EncuestaMadurez",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "EncuestaRepondenteEncuestaId",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "EncuestaRepondenteRespondenteId",
                table: "Respuesta");

            migrationBuilder.AlterColumn<float>(
                name: "Valor",
                table: "Respuesta",
                type: "real",
                nullable: false,
                defaultValue: 0f,
                oldClrType: typeof(float),
                oldType: "real",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: "País, Ciudad, Unidad de Negocio, Área Diligencie la información de acuerdo con tus datos actuales");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 5,
                column: "Descripcion",
                value: "Paquete de mejoras extralegales que complementan el salario base, pueden ser monetarias o emocionales");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descripcion",
                value: "Acciones de largo plazo que apuestan por el crecimiento personal, potencializar el talento y transformar la organización");

            migrationBuilder.UpdateData(
                table: "Categoria",
                keyColumn: "Id",
                keyValue: 7,
                column: "Descripcion",
                value: "Elementos útiles para una adecuada realización de la labor");

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_Pregunta_PreguntaId",
                table: "Respuesta",
                column: "PreguntaId",
                principalTable: "Pregunta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
