using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pk.Data;
using Pk.Models;

namespace Pk.Controllers
{
    public class ModelosController : Controller
    {
        private readonly Contexto _context;

        public ModelosController(Contexto context)
        {
            _context = context;
        }

         public IActionResult Index()
        {
            var modelos = _context.Modelos.ToList();
            return View(modelos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Add(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Editar(int? id)
        {
            var modelo = await _context.Modelos.FindAsync(id);
            return View(modelo);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Modelo modelo)
        {
            if (ModelState.IsValid)
            {
                _context.Update(modelo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}