using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OrganizingFinances.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "registroDividas",
                columns: table => new
                {
                    IdRegistro = table.Column<Guid>(type: "uuid", nullable: false),
                    TituloRegistro = table.Column<string>(type: "text", nullable: false),
                    ValorRegistro = table.Column<double>(type: "double precision", nullable: false),
                    DataDeVencimento = table.Column<DateOnly>(type: "date", nullable: false),
                    Observacoes = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registroDividas", x => x.IdRegistro);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "registroDividas");
        }
    }
}
