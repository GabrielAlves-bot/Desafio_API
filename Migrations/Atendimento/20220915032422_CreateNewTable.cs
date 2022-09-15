using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Desafio_API.Migrations.Atendimento
{
    public partial class CreateNewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Espera",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TipoAtendimento = table.Column<int>(type: "integer", nullable: false),
                    StatusPainel = table.Column<bool>(type: "boolean", nullable: false),
                    DtEmissao = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Espera", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Atendimento",
                columns: table => new
                {
                    ID = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Mesa = table.Column<int>(type: "integer", nullable: false),
                    DtAtendimento = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IDEspera = table.Column<int>(type: "integer", nullable: false),
                    EsperaID = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Atendimento", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Atendimento_Espera_EsperaID",
                        column: x => x.EsperaID,
                        principalTable: "Espera",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Atendimento_EsperaID",
                table: "Atendimento",
                column: "EsperaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Atendimento");

            migrationBuilder.DropTable(
                name: "Espera");
        }
    }
}
