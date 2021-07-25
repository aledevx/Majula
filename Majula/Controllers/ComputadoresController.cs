using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Pk.Data;
using Pk.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Pk.Services;

namespace Pk.Controllers
{
    public class ComputadoresController : Controller
    {
        private readonly Contexto _context;
        private readonly GeradorListas _geradorListas;

        public ComputadoresController(Contexto context, GeradorListas geradorListas)
        {
            _context = context;
            _geradorListas = geradorListas;
        }

        public IActionResult Index()
        {
            var computadores = _context.Computadores;
            return View(computadores.ToList());
        }

        public IActionResult Criar()
        {
            ViewBag.Status = _geradorListas.ListaStatus();
            return View();
        }
        [HttpPost]
        public async Task<ActionResult> Criar(Computador computador)
        {
            if (ModelState.IsValid)
            {
                _context.Add(computador);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<ActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = await _context.Computadores.Include(m => m.Monitores)
            .FirstOrDefaultAsync(c => c.Id == id);

            if (computador == null)
            {
                return NotFound();
            }

            return View(computador);

        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = _context.Computadores.FirstOrDefault(c => c.Id == id);
            ViewBag.Status = _geradorListas.ListaStatus();
            if (computador == null)
            {
                return NotFound();
            }
            return View(computador);
        }

        [HttpPost]
        public async Task<ActionResult> Editar(Computador computador)
        {

            if (ModelState.IsValid)
            {
                _context.Update(computador);
                await _context.SaveChangesAsync();
                return RedirectToAction("Detalhes", "Computadores", new { id = computador.Id });
            }

            // ViewBag.Status = new SelectList(_geradorListas.ListaStatus);

            return View();
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var computador = _context.Computadores.Find(id);

            if (computador == null)
            {
                return NotFound();
            }

            return View(computador);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmarExclussao(Computador computador)
        {
            if (ModelState.IsValid)
            {
                _context.Remove(computador);
                await _context.SaveChangesAsync();
                RedirectToAction(nameof(Index));
            }
            return View();
        }


    }
}