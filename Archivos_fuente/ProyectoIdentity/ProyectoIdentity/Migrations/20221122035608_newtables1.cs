using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProyectoIdentity.Migrations
{
    public partial class newtables1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespondenteDemografico_Demograficos_DemograficosId",
                table: "RespondenteDemografico");

            migrationBuilder.DropColumn(
                name: "DemograficoId",
                table: "RespondenteDemografico");

            migrationBuilder.AlterColumn<int>(
                name: "DemograficosId",
                table: "RespondenteDemografico",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RespondenteDemografico_Demograficos_DemograficosId",
                table: "RespondenteDemografico",
                column: "DemograficosId",
                principalTable: "Demograficos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RespondenteDemografico_Demograficos_DemograficosId",
                table: "RespondenteDemografico");

            migrationBuilder.AlterColumn<int>(
                name: "DemograficosId",
                table: "RespondenteDemografico",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DemograficoId",
                table: "RespondenteDemografico",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_RespondenteDemografico_Demograficos_DemograficosId",
                table: "RespondenteDemografico",
                column: "DemograficosId",
                principalTable: "Demograficos",
                principalColumn: "Id");
        }
    }
}
