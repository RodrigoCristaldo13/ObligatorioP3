using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Papeleria.AccesoDatos.Migrations
{
    /// <inheritdoc />
    public partial class AlterMovimientos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Articulos_ArticuloId",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_TiposMovimientos_TipoMovimientoId",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Usuarios_EncargadoId",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_ArticuloId",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_EncargadoId",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "ArticuloId",
                table: "Movimientos");

            migrationBuilder.DropColumn(
                name: "EncargadoId",
                table: "Movimientos");

            migrationBuilder.RenameColumn(
                name: "TipoMovimientoId",
                table: "Movimientos",
                newName: "IdEncargado");

            migrationBuilder.RenameIndex(
                name: "IX_Movimientos_TipoMovimientoId",
                table: "Movimientos",
                newName: "IX_Movimientos_IdEncargado");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_IdArticulo",
                table: "Movimientos",
                column: "IdArticulo");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_IdTipoMovimiento",
                table: "Movimientos",
                column: "IdTipoMovimiento");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Articulos_IdArticulo",
                table: "Movimientos",
                column: "IdArticulo",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_TiposMovimientos_IdTipoMovimiento",
                table: "Movimientos",
                column: "IdTipoMovimiento",
                principalTable: "TiposMovimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Usuarios_IdEncargado",
                table: "Movimientos",
                column: "IdEncargado",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Articulos_IdArticulo",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_TiposMovimientos_IdTipoMovimiento",
                table: "Movimientos");

            migrationBuilder.DropForeignKey(
                name: "FK_Movimientos_Usuarios_IdEncargado",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_IdArticulo",
                table: "Movimientos");

            migrationBuilder.DropIndex(
                name: "IX_Movimientos_IdTipoMovimiento",
                table: "Movimientos");

            migrationBuilder.RenameColumn(
                name: "IdEncargado",
                table: "Movimientos",
                newName: "TipoMovimientoId");

            migrationBuilder.RenameIndex(
                name: "IX_Movimientos_IdEncargado",
                table: "Movimientos",
                newName: "IX_Movimientos_TipoMovimientoId");

            migrationBuilder.AddColumn<int>(
                name: "ArticuloId",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EncargadoId",
                table: "Movimientos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_ArticuloId",
                table: "Movimientos",
                column: "ArticuloId");

            migrationBuilder.CreateIndex(
                name: "IX_Movimientos_EncargadoId",
                table: "Movimientos",
                column: "EncargadoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Articulos_ArticuloId",
                table: "Movimientos",
                column: "ArticuloId",
                principalTable: "Articulos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_TiposMovimientos_TipoMovimientoId",
                table: "Movimientos",
                column: "TipoMovimientoId",
                principalTable: "TiposMovimientos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Movimientos_Usuarios_EncargadoId",
                table: "Movimientos",
                column: "EncargadoId",
                principalTable: "Usuarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
