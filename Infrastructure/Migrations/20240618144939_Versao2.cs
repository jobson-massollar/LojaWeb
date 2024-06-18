using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Versao2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Produtos_CodigoBarras_Valor",
                table: "Produtos",
                column: "CodigoBarras_Valor",
                unique: true);

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Clientes_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Clientes_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Clientes\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Clientes\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Enderecos_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Enderecos_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Enderecos\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Enderecos\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Itens_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Itens_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Itens\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Itens\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Pedidos_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Pedidos_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Pedidos\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Pedidos\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Preferencias_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Preferencias_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Preferencias\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Preferencias\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Produtos_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Produtos_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Produtos\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Produtos\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS UFs_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS UFs_AfterUpdate \r\n         AFTER UPDATE\r\n            ON UFs\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE UFs\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Produtos_CodigoBarras_Valor",
                table: "Produtos");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Clientes_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Clientes_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Clientes\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Clientes\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Enderecos_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Enderecos_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Enderecos\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Enderecos\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Itens_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Itens_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Itens\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Itens\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Pedidos_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Pedidos_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Pedidos\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Pedidos\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Preferencias_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Preferencias_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Preferencias\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Preferencias\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS Produtos_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS Produtos_AfterUpdate \r\n         AFTER UPDATE\r\n            ON Produtos\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE Produtos\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");

            migrationBuilder.Sql("\r\nDROP TRIGGER IF EXISTS UFs_AfterUpdate;\r\nCREATE TRIGGER IF NOT EXISTS UFs_AfterUpdate \r\n         AFTER UPDATE\r\n            ON UFs\r\n          WHEN old.UpdatedAt <> CURRENT_TIMESTAMP\r\nBEGIN\r\n    UPDATE UFs\r\n       SET UpdatedAt = CURRENT_TIMESTAMP\r\n     WHERE id = OLD.id;\r\nEND;\r\n");
        }
    }
}
