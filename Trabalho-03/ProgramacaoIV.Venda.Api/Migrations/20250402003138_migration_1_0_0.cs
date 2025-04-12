using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProgramacaoIV.Venda.Api.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Configuração de charset para o banco
            migrationBuilder.AlterDatabase()
                .Annotation("MySQL:Charset", "utf8mb4");

            // Tabela de Clientes
            migrationBuilder.CreateTable(
                name: "CLIENTE",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    NOME = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    CPF = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    ENDERECO = table.Column<string>(type: "varchar(200)", maxLength: 200, nullable: false),
                    TELEFONE = table.Column<string>(type: "varchar(11)", maxLength: 11, nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CRIADO_EM = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATUALIZADO_EM = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CLIENTE", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            // Tabela de Produtos
            migrationBuilder.CreateTable(
                name: "PRODUTO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    EAN = table.Column<string>(type: "varchar(13)", maxLength: 13, nullable: false),
                    DESCRICAO = table.Column<string>(type: "varchar(100)", maxLength: 100, nullable: false),
                    PRECO_COMPRA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PRECO_VENDA = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ESTOQUE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CRIADO_EM = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATUALIZADO_EM = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PRODUTO", x => x.ID);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            // Tabela de Transações (Venda ou Compra)
            migrationBuilder.CreateTable(
                name: "TRANSACAO",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    CLIENTE_ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CRIADO_EM = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATUALIZADO_EM = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACAO", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSACAO_CLIENTE",
                        column: x => x.CLIENTE_ID,
                        principalTable: "CLIENTE",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            // Itens das Transações
            migrationBuilder.CreateTable(
                name: "TRANSACAO_ITEM",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    PRODUTO_ID = table.Column<Guid>(type: "char(36)", nullable: false),
                    VALOR_ITEM = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QUANTIDADE = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    TRANSACAO_ID = table.Column<Guid>(type: "char(36)", nullable: true),
                    ATIVO = table.Column<bool>(type: "tinyint(1)", nullable: false),
                    CRIADO_EM = table.Column<DateTime>(type: "datetime(6)", nullable: false),
                    ATUALIZADO_EM = table.Column<DateTime>(type: "datetime(6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TRANSACAO_ITEM", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TRANSACAO_ITEM_PRODUTO",
                        column: x => x.PRODUTO_ID,
                        principalTable: "PRODUTO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_TRANSACAO_ITEM_TRANSACAO",
                        column: x => x.TRANSACAO_ID,
                        principalTable: "TRANSACAO",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                })
                .Annotation("MySQL:Charset", "utf8mb4");

            // Índices
            migrationBuilder.CreateIndex(
                name: "IX_TRANSACAO_CLIENTE_ID",
                table: "TRANSACAO",
                column: "CLIENTE_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACAO_ITEM_TRANSACAO_ID",
                table: "TRANSACAO_ITEM",
                column: "TRANSACAO_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TRANSACAO_ITEM_PRODUTO_ID",
                table: "TRANSACAO_ITEM",
                column: "PRODUTO_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "TRANSACAO_ITEM");
            migrationBuilder.DropTable(name: "TRANSACAO");
            migrationBuilder.DropTable(name: "PRODUTO");
            migrationBuilder.DropTable(name: "CLIENTE");
        }
    }
}
