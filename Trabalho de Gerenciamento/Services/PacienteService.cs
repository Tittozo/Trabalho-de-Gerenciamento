using Trabalho_de_Gerenciamento.Data;
using Trabalho_de_Gerenciamento.Models;

namespace Trabalho_de_Gerenciamento.Services
{
    public class PacienteService
    {
        // Contexto utilizado para acessar o banco de dados
        private readonly AppDbContext _context;

        // Recebe o AppDbContext através da injeção de dependência
        public PacienteService(AppDbContext context)
        {
            _context = context;
        }

        // Lista todos os pacientes cadastrados
        public IEnumerable<Pacientes> Listar()
        {
            return _context.Pacientes.ToList();
        }

        // Busca um paciente pelo ID
        public Pacientes? BuscarPorId(int id)
        {
            return _context.Pacientes.Find(id);
        }

        // Cadastra um novo paciente
        public void Cadastrar(Pacientes paciente)
        {
            _context.Pacientes.Add(paciente);
            _context.SaveChanges();
        }

        // Atualiza os dados de um paciente
        public void Atualizar(Pacientes paciente)
        {
            _context.Pacientes.Update(paciente);
            _context.SaveChanges();
        }

        // Exclui um paciente
        public void Excluir(Pacientes paciente)
        {
            _context.Pacientes.Remove(paciente);
            _context.SaveChanges();
        }
    }
}