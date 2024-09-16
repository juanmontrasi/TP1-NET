using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto_academia.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTipoPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Tipo_Persona",
                table: "Personas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Tipo_Persona",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
