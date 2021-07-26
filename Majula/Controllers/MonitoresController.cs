using System;
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

        // public async Task<IActionResult> AddMonitor(string searchString, int? ComputadorId)
        // {

        //     if (searchString == null)
        //     {
        //         ViewBag.monitorNaoEncontrado = true;
        //     }

        //     var monitores = _context.Monitores.Where(m => m.Tombamento.Contains(searchString));

        //     if (searchString != null && monitores.Count() == 0)
        //     {
        //         ViewBag.monitorNaoEncontrado = false;
        //     }
        //     else
        //     {
        //         ViewBag.monitorNaoEncontrado = true;
        //     }

        //     return View(await monitores.FirstOrDefaultAsync());

        // }
        public async Task<IActionResult> Index(string searchString)
        {

            var monitores = from m in _context.Monitores
                            select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                monitores = monitores.Where(s => s.Tombamento.Contains(searchString));
                ViewBag.monitorNaoEncontrado = false;
            }
            else
            {
                ViewBag.monitorNaoEncontrado = true;
            }
            return View(await monitores.ToListAsync());
        }

        public IActionResult Criar(int? computadorId)
        {
            var monitor = new Monitor();
            monitor.ComputadorId = computadorId;
            ViewBag.Status = _geradorListas.ListaStatus();
            return View(monitor);
        }
        [HttpPost]
        public async Task<IActionResult> Criar(Monitor monitor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(monitor);
                await _context.SaveChangesAsync();
                if (monitor.ComputadorId == null)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return RedirectToAction("Detalhes", "Computadores", new {id = monitor.ComputadorId});
                }

            }

            return View();
        }
        // public IActionResult AddMonitor(int? id)
        // {
        //     if (id == null)
        //     {
        //         return NotFound();
        //     }
        //    var computador = _context.Computadores.Find(id);
        //     ViewBag.Status = _geradorListas.ListaStatus();
        //     return View(computador);

        // }
        // [HttpPost]
        // public async Task<IActionResult> AddMonitor(Computador computador, Monitor monitor)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         monitor.ComputadorId = computador.Id;
        //         _context.Add(monitor);
        //         await _context.SaveChangesAsync();
        //          return RedirectToAction("Detalhes", "Computadores", new { id = computador.Id });
        //     }

        //     return View();
        // }

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