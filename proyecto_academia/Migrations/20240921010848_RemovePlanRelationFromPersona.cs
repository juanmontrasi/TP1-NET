using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace proyecto_academia.Migrations
{
    /// <inheritdoc />
    public partial class RemovePlanRelationFromPersona : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Personas_Planes_IdPlan",
                table: "Personas");

            migrationBuilder.DropIndex(
                name: "IX_Personas_IdPlan",
                table: "Personas");

            migrationBuilder.DropColumn(
                name: "IdPlan",
                table: "Personas");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPlan",
                table: "Personas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Personas_IdPlan",
                table: "Personas",
                column: "IdPlan");

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
