using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace AutoGlass.Infra.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fornecedor",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fornecedor", x => x.Codigo);
                });

            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    Codigo = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DataFabricacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataValidade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataInclusao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Situacao = table.Column<bool>(type: "bit", nullable: false),
                    CodigoFornecedor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.Codigo);
                    table.ForeignKey(
                        name: "FK_Produto_Fornecedor_CodigoFornecedor",
                        column: x => x.CodigoFornecedor,
                        principalTable: "Fornecedor",
                        principalColumn: "Codigo",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Fornecedor",
                columns: new[] { "Codigo", "CNPJ", "DataInclusao", "Descricao", "Situacao" },
                values: new object[,]
                {
                    { 1, "12775524000133", new DateTime(2023, 12, 17, 19, 50, 21, 18, DateTimeKind.Local).AddTicks(2088), "Fornecedor 1", true },
                    { 2, "09809005000134", new DateTime(2023, 12, 17, 14, 50, 21, 20, DateTimeKind.Local).AddTicks(282), "Fornecedor 2", true },
                    { 3, "40575582000159", new DateTime(2023, 12, 16, 19, 50, 21, 20, DateTimeKind.Local).AddTicks(466), "Fornecedor 3", true },
                    { 4, "27283103000162", new DateTime(2023, 12, 10, 19, 50, 21, 20, DateTimeKind.Local).AddTicks(488), "Fornecedor 4", true }
                });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Codigo", "CodigoFornecedor", "DataFabricacao", "DataInclusao", "DataValidade", "Descricao", "Situacao" },
                values: new object[] { 1, 1, new DateTime(2023, 10, 20, 20, 40, 10, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 17, 19, 50, 21, 30, DateTimeKind.Local).AddTicks(1894), new DateTime(2024, 10, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Arroz", true });

            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Codigo", "CodigoFornecedor", "DataFabricacao", "DataInclusao", "DataValidade", "Descricao", "Situacao" },
                values: new object[] { 2, 2, new DateTime(2023, 11, 15, 7, 40, 10, 0, DateTimeKind.Unspecified), new DateTime(2023, 12, 17, 19, 50, 21, 30, DateTimeKind.Local).AddTicks(2568), new DateTime(2024, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Coca Cola", true });

            migrationBuilder.CreateIndex(
                name: "IX_Produto_CodigoFornecedor",
                table: "Produto",
                column: "CodigoFornecedor");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");

            migrationBuilder.DropTable(
                name: "Fornecedor");
        }
    }
}
