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
    public class EquipamentosController : Controller
    {
        private readonly Contexto _context;
         private readonly GeradorListas _geradorListas;

        public EquipamentosController(Contexto context, GeradorListas geradorListas)
        {
            _context = context;
            _geradorListas = geradorListas;
        }

        public IActionResult Index()
        {
            var equipamentos = _context.Equipamentos;
            return View(equipamentos.ToList());
        }

        public IActionResult Criar()
        {
            ViewBag.Status = _geradorListas.ListaStatus();
            ViewBag.Categoria = _geradorListas.ListaCategoria();
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Descricao");
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Criar(Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(equipamento);
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

            var equipamento = await _context.Equipamentos.FirstOrDefaultAsync(e => e.Id == id);

            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }

        public async Task<IActionResult> Editar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamentos.FindAsync(id);
            ViewBag.Categoria = _geradorListas.ListaCategoria();
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Descricao");

            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }
        [HttpPost]
        public async Task<IActionResult> Editar(Equipamento equipamento)
        {

            if (ModelState.IsValid)
            {
                _context.Update(equipamento);
                await _context.SaveChangesAsync();
                return RedirectToAction("Detalhes", "Equipamentos", new {id = equipamento.Id});
            }
            return View();
        }

        public IActionResult Excluir(int? id)
        {
            if(id == null)
            {
                return NotFound();
            }

            var equipamento = _context.Equipamentos.Find(id);

            if(equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmarExclussao( Equipamento equipamento)
        {
            if(ModelState.IsValid)
            {
                _context.Remove(equipamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

    }
}