using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Trabalho_de_Gerenciamento.Migrations
{
    /// <inheritdoc />
    public partial class SeedPacientes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pacientes",
                columns: new[] { "Id", "CPF", "DataNascimento", "Endereco", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "667.990.787-90", new DateTime(1990, 5, 10, 0, 0, 0, 0, DateTimeKind.Utc), "Rua Alberto Biason, 12", "João Silva", "18998787654" },
                    { 2, "231.231.241-24", new DateTime(1991, 8, 3, 0, 0, 0, 0, DateTimeKind.Utc), "Rua Lucas Teodoro, 60", "Mateus Sousa", "18999095432" },
                    { 3, "123.456.789-00", new DateTime(1985, 8, 15, 0, 0, 0, 0, DateTimeKind.Utc), "Rua Gabriel Domingues, 39", "Maria Oliveira", "18995456789" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pacientes",
                keyColumn: "Id",
                keyValue: 3);
        }
    }
}
