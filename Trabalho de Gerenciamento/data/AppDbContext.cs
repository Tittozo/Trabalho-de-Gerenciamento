using Microsoft.EntityFrameworkCore;
using Trabalho_de_Gerenciamento.Models;

namespace Trabalho_de_Gerenciamento.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { 

        }

        public DbSet<Paciente> Pacientes { get; set; }
    }
}