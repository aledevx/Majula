using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pk.Data;
using Pk.Models;

namespace Pk.Controllers
{
    public class MemoriasController : Controller
    {
        private readonly Contexto _context;
        public MemoriasController(Contexto context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var marcas = _context.Memorias.ToList();
            return View(marcas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Memoria memoria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(memoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Editar(int? id)
        {
            var marca = await _context.Memorias.FindAsync(id);
            return View(marca);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Memoria memoria)
        {
            if (ModelState.IsValid)
            {
                _context.Update(memoria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}