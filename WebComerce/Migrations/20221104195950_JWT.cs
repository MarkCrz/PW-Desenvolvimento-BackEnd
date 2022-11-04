using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebComerce.Migrations
{
    public partial class JWT : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEscolhido_Produtos_produtoid",
                table: "ProdutoEscolhido");

            migrationBuilder.DropColumn(
                name: "password",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "produtoid",
                table: "ProdutoEscolhido",
                newName: "produtoId");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoEscolhido_produtoid",
                table: "ProdutoEscolhido",
                newName: "IX_ProdutoEscolhido_produtoId");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "Usuarios",
                type: "varbinary(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "Usuarios",
                type: "varbinary(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: new byte[0]);

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEscolhido_Produtos_produtoId",
                table: "ProdutoEscolhido",
                column: "produtoId",
                principalTable: "Produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ProdutoEscolhido_Produtos_produtoId",
                table: "ProdutoEscolhido");

            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "produtoId",
                table: "ProdutoEscolhido",
                newName: "produtoid");

            migrationBuilder.RenameIndex(
                name: "IX_ProdutoEscolhido_produtoId",
                table: "ProdutoEscolhido",
                newName: "IX_ProdutoEscolhido_produtoid");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Usuarios",
                type: "varchar(60)",
                maxLength: 60,
                nullable: false,
                defaultValue: "",
                collation: "utf8mb4_0900_ai_ci")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddForeignKey(
                name: "FK_ProdutoEscolhido_Produtos_produtoid",
                table: "ProdutoEscolhido",
                column: "produtoid",
                principalTable: "Produtos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
