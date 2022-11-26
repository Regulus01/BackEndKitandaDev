using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Repository.Migrations
{
    public partial class Cria_EnderecoCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "End_Bairro",
                table: "Cliente",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "End_Cep",
                table: "Cliente",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "End_Cidade",
                table: "Cliente",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "End_Referencia",
                table: "Cliente",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "End_UF",
                table: "Cliente",
                type: "text",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "End_Bairro",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "End_Cep",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "End_Cidade",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "End_Referencia",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "End_UF",
                table: "Cliente");
        }
    }
}
