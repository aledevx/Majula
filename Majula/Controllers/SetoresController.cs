using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pk.Data;
using Pk.Models;

namespace Pk.Controllers
{
    public class SetoresController : Controller
    {
        private readonly Contexto _context;

        public SetoresController(Contexto context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var setores = await _context.Setores.ToListAsync();
            return View(setores);
        }

        public IActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Setor setor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(setor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<IActionResult> Editar(int? id)
        {
            var setor = await _context.Setores.FindAsync(id);
            return View(setor);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Setor setor)
        {
            _context.Update(setor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult GetSetores()
        {
            var setores = _context.Setores.ToList();
            return Json(setores);
        }
    }
}