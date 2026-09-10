
using Microsoft.AspNetCore.Mvc;
using Trabalho_de_Gerenciamento.Data;
using Trabalho_de_Gerenciamento.Models;

namespace Trabalho_de_Gerenciamento.Controllers
{
    public class PacientesController : Controller
    {
        private readonly AppDbContext _context;

        public PacientesController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View(_context.Pacientes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Pacientes paciente)
        {
            if (ModelState.IsValid)
            {
                _context.Pacientes.Add(paciente);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(paciente);
        }
    }
}