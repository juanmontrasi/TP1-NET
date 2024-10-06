using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto_academia.Migrations
{
    /// <inheritdoc />
    public partial class Update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cursos_Comisiones_IdComision",
                table: "Cursos");

            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Planes_IdPlan",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_IdPlan",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdPlan",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "Legajo",
                table: "Personas");

            

            migrationBuilder.RenameColumn(
                name: "Cupo",
                table: "AlumnoInscripciones",
                newName: "Nota");

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

            migrationBuilder.RenameColumn(
                name: "Nota",
                table: "AlumnoInscripciones",
                newName: "Cupo");

            migrationBuilder.AddColumn<int>(
                name: "IdPlan",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Legajo",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

          

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdPlan",
                table: "Personas",
                column: "IdPlan");

            migrationBuilder.AddForeignKey(
                name: "FK_Cursos_Comisiones_IdComision",
                table: "Cursos",
                column: "IdComision",
                principalTable: "Comisiones",
                principalColumn: "IdComision",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Personas_Planes_IdPlan",
                table: "Personas",
                column: "IdPlan",
                principalTable: "Planes",
                principalColumn: "IdPlan",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
