using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CalculadoraLaboralBackend.Migrations
{
    public partial class i : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servicio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tecnico = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    servicioRealizado = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    fechaDeInicio = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaDeInicio = table.Column<int>(type: "int", nullable: false),
                    fechaDeFinalizacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    horaDeFinalizacion = table.Column<int>(type: "int", nullable: false),
                    semanaDelAno = table.Column<int>(type: "int", nullable: false),
                    cantidadDeHoras = table.Column<int>(type: "int", nullable: false),
                    tipoDeHora = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servicio", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servicio");
        }
    }
}
