using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pk.Data;
using Pk.Models;

namespace Pk.Controllers
{
    public class MarcasController : Controller
    {
        private readonly Contexto _context;

        public MarcasController(Contexto context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var marcas = _context.Marcas.ToList();
            return View(marcas);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Add(marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Editar(int? id)
        {
            var marca = await _context.Marcas.FindAsync(id);
            return View(marca);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Marca marca)
        {
            if (ModelState.IsValid)
            {
                _context.Update(marca);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}