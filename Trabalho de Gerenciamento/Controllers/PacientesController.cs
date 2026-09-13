using Microsoft.AspNetCore.Mvc;
using Trabalho_de_Gerenciamento.Data;
using Trabalho_de_Gerenciamento.Models;

namespace Trabalho_de_Gerenciamento.Controllers
{
    public class PacientesController : Controller
    {
        // Contexto utilizado para acessar o banco de dados
        private readonly AppDbContext _context;

        // Recebe o AppDbContext através da injeção de dependência
        public PacientesController(AppDbContext context)
        {
            _context = context;
        }

        // Lista todos os pacientes cadastrados
        public IActionResult Index()
        {
            return View(_context.Pacientes);
        }

        // Abre a tela de cadastro
        public IActionResult Create()
        {
            return View();
        }

        // Recebe os dados enviados pelo formulário de cadastro
        [HttpPost]
        public IActionResult Create(Pacientes paciente)
        {
            // Verifica se os dados enviados são válidos
            if (ModelState.IsValid)
            {
                // Adiciona o paciente ao banco de dados
                _context.Pacientes.Add(paciente);

                // Salva as alterações no banco de dados
                _context.SaveChanges();

                // Retorna para a lista de pacientes
                return RedirectToAction("Index");
            }

            // Caso existam erros de validação, retorna para o formulário
            return View(paciente);
        }

        // Abre a tela de edição do paciente
        public IActionResult Edit(int? id)
        {
            // Verifica se o ID foi informado
            if (id == null)
            {
                return NotFound();
            }

            // Procura o paciente pelo ID
            var paciente = _context.Pacientes.Find(id);

            // Verifica se o paciente foi encontrado
            if (paciente == null)
            {
                return NotFound();
            }

            // Envia o paciente encontrado para a View
            return View(paciente);
        }

        // Recebe os dados alterados pelo formulário de edição
        [HttpPost]
        public IActionResult Edit(int id, Pacientes paciente)
        {
            // Verifica se o ID informado corresponde ao paciente
            if (id != paciente.Id)
            {
                return NotFound();
            }

            // Verifica se os dados alterados são válidos
            if (ModelState.IsValid)
            {
                // Atualiza os dados do paciente
                _context.Pacientes.Update(paciente);

                // Salva as alterações no banco de dados
                _context.SaveChanges();

                // Retorna para a lista de pacientes
                return RedirectToAction("Index");
            }

            // Caso existam erros, retorna para o formulário de edição
            return View(paciente);
        }

        // Abre a tela de confirmação de exclusão
        public IActionResult Delete(int? id)
        {
            // Verifica se o ID foi informado
            if (id == null)
            {
                return NotFound();
            }

            // Procura o paciente pelo ID
            var paciente = _context.Pacientes.Find(id);

            // Verifica se o paciente foi encontrado
            if (paciente == null)
            {
                return NotFound();
            }

            // Envia o paciente para a tela de confirmação
            return View(paciente);
        }

        // Recebe a confirmação de exclusão
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Procura o paciente pelo ID
            var paciente = _context.Pacientes.Find(id);

            // Verifica se o paciente existe
            if (paciente == null)
            {
                return NotFound();
            }

            // Remove o paciente do contexto
            _context.Pacientes.Remove(paciente);

            // Salva a exclusão no banco de dados
            _context.SaveChanges();

            // Retorna para a lista de pacientes
            return RedirectToAction("Index");
        }
    }
}

