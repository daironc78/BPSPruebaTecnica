using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class IdentityCoreInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Estudiante",
                columns: table => new
                {
                    IdEstudiante = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Estudiante", x => x.IdEstudiante);
                });

            migrationBuilder.CreateTable(
                name: "Profesor",
                columns: table => new
                {
                    IdProfesor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Profesor", x => x.IdProfesor);
                });

            migrationBuilder.CreateTable(
                name: "Nota",
                columns: table => new
                {
                    IdEstudiante = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProfesor = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdNota = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Valor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Nota", x => new { x.IdNota });
                    table.ForeignKey(
                        name: "FK_Nota_Estudiante_IdEstudiante",
                        column: x => x.IdEstudiante,
                        principalTable: "Estudiante",
                        principalColumn: "IdEstudiante",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Nota_Profesor_IdProfesor",
                        column: x => x.IdProfesor,
                        principalTable: "Profesor",
                        principalColumn: "IdProfesor",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "Nota_IdNota",
                table: "Nota",
                column: "IdNota");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Nota");

            migrationBuilder.DropTable(
                name: "Estudiante");

            migrationBuilder.DropTable(
                name: "Profesor");
        }
    }
}
