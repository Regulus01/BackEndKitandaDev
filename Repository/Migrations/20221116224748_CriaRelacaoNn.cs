using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class CriaRelacaoNn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ClienteProduto",
                columns: table => new
                {
                    ClientesClienteId = table.Column<Guid>(type: "uuid", nullable: false),
                    ProdutosId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClienteProduto", x => new { x.ClientesClienteId, x.ProdutosId });
                    table.ForeignKey(
                        name: "FK_ClienteProduto_Cliente_ClientesClienteId",
                        column: x => x.ClientesClienteId,
                        principalTable: "Cliente",
                        principalColumn: "Cliente_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ClienteProduto_Produto_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produto",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ClienteProduto_ProdutosId",
                table: "ClienteProduto",
                column: "ProdutosId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ClienteProduto");
        }
    }
}
