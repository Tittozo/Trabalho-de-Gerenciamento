using Microsoft.AspNetCore.Mvc;
using Trabalho_de_Gerenciamento.Models;
using Trabalho_de_Gerenciamento.Services;

namespace Trabalho_de_Gerenciamento.Controllers
{
    public class PacientesController : Controller
    {
        // Serviço responsável pelas operações dos pacientes
        private readonly PacienteService _service;

        // Recebe o PacienteService através da injeção de dependência
        public PacientesController(PacienteService service)
        {
            _service = service;
        }

        // Lista todos os pacientes cadastrados
        public IActionResult Index()
        {
            var pacientes = _service.Listar();

            return View(pacientes);
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
                // Solicita ao Service o cadastro do paciente
                _service.Cadastrar(paciente);

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

            // Busca o paciente através do Service
            var paciente = _service.BuscarPorId(id.Value);

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
                // Solicita ao Service a atualização do paciente
                _service.Atualizar(paciente);

                // Retorna para a lista de pacientes
                return RedirectToAction("Index");
            }

            // Caso existam erros, retorna para o formulário
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

            // Busca o paciente através do Service
            var paciente = _service.BuscarPorId(id.Value);

            // Verifica se o paciente foi encontrado
            if (paciente == null)
            {
                return NotFound();
            }

            // Envia o paciente para a tela de confirmação
            return View(paciente);
        }

        // Recebe a confirmação da exclusão
        [HttpPost]
        public IActionResult Delete(int id)
        {
            // Busca o paciente através do Service
            var paciente = _service.BuscarPorId(id);

            // Verifica se o paciente existe
            if (paciente == null)
            {
                return NotFound();
            }

            // Solicita ao Service a exclusão do paciente
            _service.Excluir(paciente);

            // Retorna para a lista de pacientes
            return RedirectToAction("Index");
        }
    }
}