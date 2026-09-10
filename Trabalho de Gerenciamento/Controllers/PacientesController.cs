using Microsoft.AspNetCore.Mvc;
using Trabalho_de_Gerenciamento.Data;

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
    }
}