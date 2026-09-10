using Microsoft.EntityFrameworkCore;
using Trabalho_de_Gerenciamento.Models;

namespace Trabalho_de_Gerenciamento.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Pacientes> Pacientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Pacientes aqui
            modelBuilder.Entity<Pacientes>()
                .Property(p => p.DataNascimento)
                .HasColumnType("timestamp without time zone");

            modelBuilder.Entity<Pacientes>().HasData(
                new Pacientes
                {
                    Id = 1,
                    Nome = "João Silva",
                    CPF = "667.990.787-90",
                    Telefone = "18998787654",
                    Endereco = "Rua Alberto Biason, 12",
                    DataNascimento = DateTime.SpecifyKind(
                        new DateTime(1990, 5, 10),
                        DateTimeKind.Utc)
                },
                new Pacientes
                {
                    Id = 2,
                    Nome = "Mateus Sousa",
                    CPF = "231.231.241-24",
                    Telefone = "18999095432",
                    Endereco = "Rua Lucas Teodoro, 60",
                    DataNascimento = DateTime.SpecifyKind(
                        new DateTime(1991, 8, 3),
                        DateTimeKind.Utc)
                },
                new Pacientes
                {
                    Id = 3,
                    Nome = "Maria Oliveira",
                    CPF = "123.456.789-00",
                    Telefone = "18995456789",
                    Endereco = "Rua Gabriel Domingues, 39",
                    DataNascimento = DateTime.SpecifyKind(
                        new DateTime(1985, 8, 15),
                        DateTimeKind.Utc)
                }
            );
        }
    }
}