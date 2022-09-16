using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio_API.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "tb_espera",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    tipo_atendimento = table.Column<int>(type: "integer", nullable: false),
                    status_painel = table.Column<bool>(type: "boolean", nullable: false),
                    data_emissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_espera", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "tb_atendimento",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    mesa = table.Column<int>(type: "integer", nullable: false),
                    data_atendimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EsperaId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tb_atendimento", x => x.id);
                    table.ForeignKey(
                        name: "FK_tb_atendimento_tb_espera_EsperaId",
                        column: x => x.EsperaId,
                        principalTable: "tb_espera",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tb_atendimento_EsperaId",
                table: "tb_atendimento",
                column: "EsperaId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tb_atendimento");

            migrationBuilder.DropTable(
                name: "tb_espera");
        }
    }
}
