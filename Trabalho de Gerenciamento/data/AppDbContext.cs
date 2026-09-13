
using Microsoft.EntityFrameworkCore;
using Trabalho_de_Gerenciamento.Models;

namespace Trabalho_de_Gerenciamento.Data
{
    public class AppDbContext : DbContext
    {
        // Construtor que recebe as configurações do banco de dados
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        // Representa a tabela de pacientes no banco de dados
        public DbSet<Pacientes> Pacientes { get; set; }

        // Configurações adicionais das entidades e dados iniciais
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define o tipo da coluna DataNascimento no PostgreSQL
            modelBuilder.Entity<Pacientes>()
                .Property(p => p.DataNascimento)
                .HasColumnType("timestamp without time zone");

            // Adiciona pacientes iniciais ao banco de dados
            modelBuilder.Entity<Pacientes>().HasData(

                // Primeiro paciente cadastrado inicialmente
                new Pacientes
                {
                    Id = 1,
                    Nome = "João Silva",
                    CPF = "667.990.787-90",
                    Telefone = "18998787654",
                    Endereco = "Rua Alberto Biason, 12",

                    // Define a data sem considerar fuso horário
                    DataNascimento = DateTime.SpecifyKind(
                        new DateTime(1990, 5, 10),
                        DateTimeKind.Utc)
                },

                // Segundo paciente cadastrado inicialmente
                new Pacientes
                {
                    Id = 2,
                    Nome = "Mateus Sousa",
                    CPF = "231.231.241-24",
                    Telefone = "18999095432",
                    Endereco = "Rua Lucas Teodoro, 60",

                    // Define a data sem considerar fuso horário
                    DataNascimento = DateTime.SpecifyKind(
                        new DateTime(1991, 8, 3),
                        DateTimeKind.Utc)
                },

                // Terceiro paciente cadastrado inicialmente
                new Pacientes
                {
                    Id = 3,
                    Nome = "Maria Oliveira",
                    CPF = "123.456.789-00",
                    Telefone = "18995456789",
                    Endereco = "Rua Gabriel Domingues, 39",

                    // Define a data sem considerar fuso horário
                    DataNascimento = DateTime.SpecifyKind(
                        new DateTime(1985, 8, 15),
                        DateTimeKind.Utc)
                }
            );
        }
    }
}

