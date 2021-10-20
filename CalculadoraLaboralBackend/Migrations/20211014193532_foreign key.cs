using Microsoft.EntityFrameworkCore.Migrations;

namespace CalculadoraLaboralBackend.Migrations
{
    public partial class foreignkey : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Area_AreaId",
                table: "Colaborador");

            migrationBuilder.DropColumn(
                name: "Fk_Area",
                table: "Colaborador");

            migrationBuilder.RenameColumn(
                name: "tecnico",
                table: "Servicio",
                newName: "Fk_ColaboradorId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Area",
                newName: "AreaId");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Colaborador",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Area_AreaId",
                table: "Colaborador",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "AreaId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Colaborador_Area_AreaId",
                table: "Colaborador");

            migrationBuilder.RenameColumn(
                name: "Fk_ColaboradorId",
                table: "Servicio",
                newName: "tecnico");

            migrationBuilder.RenameColumn(
                name: "AreaId",
                table: "Area",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "AreaId",
                table: "Colaborador",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Fk_Area",
                table: "Colaborador",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Colaborador_Area_AreaId",
                table: "Colaborador",
                column: "AreaId",
                principalTable: "Area",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
