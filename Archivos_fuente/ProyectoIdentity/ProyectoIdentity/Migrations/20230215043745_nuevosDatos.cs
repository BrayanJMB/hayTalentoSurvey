using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class nuevosDatos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_Respondente_RespondenteId",
                table: "Respuesta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Respuesta",
                table: "Respuesta");

            migrationBuilder.AlterColumn<Guid>(
                name: "RespondenteId",
                table: "Respuesta",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Respuesta",
                type: "int",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<float>(
                name: "PonderadoRespuesta",
                table: "EncuestaRepondente",
                type: "real",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Respuesta",
                table: "Respuesta",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Respuesta_PreguntaId",
                table: "Respuesta",
                column: "PreguntaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_Respondente_RespondenteId",
                table: "Respuesta",
                column: "RespondenteId",
                principalTable: "Respondente",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Respuesta_Respondente_RespondenteId",
                table: "Respuesta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Respuesta",
                table: "Respuesta");

            migrationBuilder.DropIndex(
                name: "IX_Respuesta_PreguntaId",
                table: "Respuesta");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Respuesta");

            migrationBuilder.AlterColumn<Guid>(
                name: "RespondenteId",
                table: "Respuesta",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PonderadoRespuesta",
                table: "EncuestaRepondente",
                type: "int",
                nullable: false,
                oldClrType: typeof(float),
                oldType: "real");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Respuesta",
                table: "Respuesta",
                columns: new[] { "PreguntaId", "RespondenteId" });

            migrationBuilder.AddForeignKey(
                name: "FK_Respuesta_Respondente_RespondenteId",
                table: "Respuesta",
                column: "RespondenteId",
                principalTable: "Respondente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
