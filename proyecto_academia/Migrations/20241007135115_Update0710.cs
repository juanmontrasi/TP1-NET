using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto_academia.Migrations
{
    public partial class Update0710 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Eliminamos las columnas de la tabla Personas
            migrationBuilder.DropColumn(
                name: "IdPlan",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Legajo",
                table: "Personas");

           /* migrationBuilder.DropColumn(
                name: "Tipo_Persona",
                table: "Personas");

            // Renombramos la columna en la tabla AlumnoInscripciones
            migrationBuilder.RenameColumn(
                name: "Cupo",
                table: "AlumnoInscripciones",
                newName: "Nota"); */
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Restauramos las columnas en la tabla Personas
            migrationBuilder.AddColumn<int>(
                name: "IdPlan",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Legajo",
                table: "Personas",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Tipo_Persona",
                table: "Personas",
                type: "int",
                nullable: true);

            // Restauramos la columna en la tabla AlumnoInscripciones
            migrationBuilder.RenameColumn(
                name: "Nota",
                table: "AlumnoInscripciones",
                newName: "Cupo");
        }
    }
}
