using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto_academia.Migrations
{
    /// <inheritdoc />
    public partial class ConfigurarEliminacionEnCascada : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Comisiones_IdComision",
                table: "Cursos");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Comisiones_IdComision",
                table: "Cursos",
                column: "IdComision",
                principalTable: "Comisiones",
                principalColumn: "IdComision",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Comisiones_IdComision",
                table: "Cursos");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Comisiones_IdComision",
                table: "Cursos",
                column: "IdComision",
                principalTable: "Comisiones",
                principalColumn: "IdComision",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
