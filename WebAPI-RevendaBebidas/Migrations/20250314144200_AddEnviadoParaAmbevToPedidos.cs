using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebAPI_RevendaBebidas.Migrations
{
    /// <inheritdoc />
    public partial class AddEnviadoParaAmbevToPedidos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "EnviadoParaAmbev",
                table: "Pedidos",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EnviadoParaAmbev",
                table: "Pedidos");
        }
    }
}
