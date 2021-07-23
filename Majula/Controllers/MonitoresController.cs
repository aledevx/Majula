using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Pk.Data;
using Pk.Models;
using Pk.Services;

namespace Pk.Controllers
{
    public class MonitoresController : Controller
    {
        private readonly Contexto _context;
        private readonly GeradorListas _geradorListas;

        public MonitoresController(Contexto context, GeradorListas geradorListas)
        {
            _context = context;
            _geradorListas = geradorListas;
        }

        public IActionResult Index()
        {
            var monitores = _context.Monitores;
            return View(monitores.ToList());
        }

        public IActionResult Criar()
        {
            ViewBag.Status = _geradorListas.ListaStatus();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Criar(Monitor monitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitor = await _context.Monitores.FirstOrDefaultAsync(m => m.Id == id);

            if (monitor == null)
            {
                return NotFound();
            }

            return View(monitor);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            ViewBag.Status = _geradorListas.ListaStatus();
            var monitor = await _context.Monitores.FindAsync(id);

            if (monitor == null)
            {
                return NotFound();
            }
            return View(monitor);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Monitor monitor)
        {

            if (ModelState.IsValid)
            {
                _context.Update(monitor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Detalhes", "Monitores", new { id = monitor.Id });
            }

            return View();

        }

        public IActionResult Excluir(int? id)
        {

            if (id == null)
            {
                return NotFound();
            }

            var monitor = _context.Monitores.Find(id);

            if (monitor == null)
            {
                return NotFound();
            }

            return View(monitor);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmarExclussao(Monitor monitor)
        {

            if (ModelState.IsValid)
            {
                _context.Remove(monitor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View();
        }




    }
}