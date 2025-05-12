using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class removeEncargadoDeMovimiento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Usuarios_IdEncargado",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_IdEncargado",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "IdEncargado",
                table: "Movimientos");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdEncargado",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_IdEncargado",
                table: "Movimientos",
                column: "IdEncargado");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Usuarios_IdEncargado",
                table: "Movimientos",
                column: "IdEncargado",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
