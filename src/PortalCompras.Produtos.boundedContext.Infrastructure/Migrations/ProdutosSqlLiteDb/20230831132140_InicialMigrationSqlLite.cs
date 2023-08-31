using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PortalCompras.Produtos.boundedContext.Infrastructure.Migrations.ProdutosSqlLiteDb
{
    /// <inheritdoc />
    public partial class InicialMigrationSqlLite : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    nome = table.Column<string>(type: "varchar(250)", nullable: false),
                    descricao = table.Column<string>(type: "varchar(500)", nullable: false),
                    ativo = table.Column<bool>(type: "INTEGER", nullable: false),
                    valor = table.Column<decimal>(type: "numeric(18,2)", nullable: false),
                    estoque = table.Column<int>(type: "INTEGER", nullable: false),
                    dataCadastro = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produtos");
        }
    }
}
