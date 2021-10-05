using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pk.Data;
using Pk.Models;

namespace Pk.Controllers
{
    public class ProcessadoresController : Controller
    {
        private readonly Contexto _context;

        public ProcessadoresController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var processadores = _context.Processadores.ToList();
            return View(processadores);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Processador processador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
        public IActionResult Editar(int? id)
        {
            var processador = _context.Processadores.Find(id);
            return View(processador);
        }
        
        [HttpPost]
        public async Task<IActionResult> Editar(Processador processador)
        {
            if (ModelState.IsValid)
            {
                _context.Update(processador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}