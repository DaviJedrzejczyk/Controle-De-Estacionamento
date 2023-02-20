using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataAccessLayer.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CARROS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PLACA = table.Column<string>(type: "varchar(8)", unicode: false, maxLength: 8, nullable: false),
                    HORARIO_ENTRADA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TEM_SAIDA = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CARROS", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "SAIDA_CARROS",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    HORARIO_SAIDA = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TOTAL_PAGO = table.Column<double>(type: "float", nullable: false),
                    PRECO = table.Column<double>(type: "float", nullable: false),
                    TEMPO_FICADO = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    TEMPO_COBRADO = table.Column<int>(type: "int", nullable: false),
                    CarroID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SAIDA_CARROS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SAIDA_CARROS_CARROS_CarroID",
                        column: x => x.CarroID,
                        principalTable: "CARROS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SAIDA_CARROS_CarroID",
                table: "SAIDA_CARROS",
                column: "CarroID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SAIDA_CARROS");

            migrationBuilder.DropTable(
                name: "CARROS");
        }
    }
}
