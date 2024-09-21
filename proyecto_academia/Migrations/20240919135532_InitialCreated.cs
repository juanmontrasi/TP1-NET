using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto_academia.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cupo",
                table: "AlumnoInscripciones",
                newName: "Nota");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nota",
                table: "AlumnoInscripciones",
                newName: "Cupo");
        }
    }
}
