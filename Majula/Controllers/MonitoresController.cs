using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
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
        private readonly ServicosMovimentacoes _servicosMovimentacoes;

        public MonitoresController(Contexto context, GeradorListas geradorListas, ServicosMovimentacoes servicosMovimentacoes)
        {
            _context = context;
            _geradorListas = geradorListas;
            _servicosMovimentacoes = servicosMovimentacoes;
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

            // var monitores = from m in _context.Monitores
            // select m; 


            var monitores = _context.Monitores.Include(m => m.Marca);
            // Convertendo um enumerable em uma Lista
            List<Monitor> monitores2 = monitores.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                monitores2 = monitores2.Where(s => s.Tombamento.Contains(searchString)).ToList();
                ViewBag.monitorNaoEncontrado = false;
            }
            else
            {
                ViewBag.monitorNaoEncontrado = true;
            }
            return View(monitores2);
        }

        public async Task<IActionResult> Vincular(int id, int computadorId)
        {
            try
            {
                var monitor = await _context.Monitores.FindAsync(id);
                monitor.ComputadorId = computadorId;
                _context.Update(monitor);
                await _context.SaveChangesAsync();

                // Busca a movimentação ativa do computador que será vinculado ao monitor
                var movAtualPc = _context.MovimentacoesPc.Where(movPc => movPc.Ativo == true && movPc.ComputadorId == computadorId)
                .Include(mov => mov.Setor).FirstOrDefault();
                // Busca o setor atual do computador que está sendo vinculado ao monitor
                var setorAtual = _context.Setores.Where(setor => setor.Sigla == movAtualPc.Setor.Sigla).FirstOrDefault();

                //Chama o serviço para desativar a movimentação que está ativa do monitor
                _servicosMovimentacoes.DesativarMovMonitor(monitor.Id);

                // Cria uma nova movimentação de monitor
                MovimentacaoMonitor movMonitor = new MovimentacaoMonitor();
                // Atribui os valores necessário para a nova movimentação e em seguida salva, 
                //assim o monitor quando vinculado é movimentado para o mesmo setor do computador escolhido
                movMonitor.MonitorId = monitor.Id;
                movMonitor.Ativo = true;
                movMonitor.DataAtual = DateTime.Now;
                movMonitor.SetorId = setorAtual.Id;
                _context.Add(movMonitor);
                await _context.SaveChangesAsync();

                return RedirectToAction("Detalhes", "Computadores", new { id = computadorId });
            }
            catch (System.Exception mensagem)
            {
                throw new Exception("Error ", mensagem);
            }

        }

        [HttpGet]
        public async Task<IActionResult> Desvincular(int? id)
        {
            var monitor = await _context.Monitores.FindAsync(id);

            int computadorId = Convert.ToInt32(monitor.ComputadorId);

            monitor.ComputadorId = null;

            _context.Update(monitor);
            await _context.SaveChangesAsync();
            return RedirectToAction("Detalhes", "Computadores", new { id = computadorId });
        }

        //Tela para selecionar o monitor quando tenta vincular com algum computador
        public async Task<IActionResult> Teste(string searchString, int? computadorId)
        {

            try
            {
                var monitores = from m in _context.Monitores
                                select m;

                ViewBag.computadorId = computadorId;

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
            catch (System.Exception mensagem)
            {
                throw new Exception("Error ", mensagem);
            }
        }

        [HttpPost]
        public void BtnTeste(int? id, int? computadorId)
        {
            var monitor = _context.Monitores.Find(id);

            monitor.ComputadorId = computadorId;

        }

        public IActionResult Criar(int? computadorId)
        {
            var monitor = new Monitor();
            monitor.ComputadorId = computadorId;
            ViewBag.Status = _geradorListas.ListaStatus();
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Descricao");
            return View(monitor);
        }
        [HttpPost]
        public async Task<IActionResult> Criar(Monitor monitor)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(monitor);
                    await _context.SaveChangesAsync();
                    var setorGti = _context.Setores.Where(setor => setor.Sigla == "GTI").FirstOrDefault();
                    MovimentacaoMonitor movMonitor = new MovimentacaoMonitor();
                    movMonitor.MonitorId = monitor.Id;
                    movMonitor.SetorId = setorGti.Id;
                    movMonitor.DataAtual = DateTime.Now;
                    movMonitor.Ativo = true;
                    _context.Add(movMonitor);
                    await _context.SaveChangesAsync();
                    if (monitor.ComputadorId == null)
                    {
                        return RedirectToAction("Detalhes", "Monitores", new { id = monitor.Id });
                    }
                    else
                    {
                        return RedirectToAction("Detalhes", "Computadores", new { id = monitor.ComputadorId });
                    }

                }

                return View();
            }
            catch (System.Exception mensagem)
            {

                throw new Exception("Put your error message here.", mensagem);
            }


        }
        public IActionResult AddMonitor(int? computadorId)
        {
            if (computadorId == null)
            {
                return NotFound();
            }
            ViewBag.computadorId = computadorId;
            var computador = _context.Computadores.Find(computadorId);
            ViewBag.Status = _geradorListas.ListaStatus();
            return View(computador);

        }
        [HttpPost]
        public async Task<IActionResult> AddMonitor(int computadorId, Monitor monitor)
        {
            if (ModelState.IsValid)
            {
                monitor.ComputadorId = computadorId;
                _context.Add(monitor);
                await _context.SaveChangesAsync();
                return RedirectToAction("Detalhes", "Computadores", new { id = computadorId });
            }

            return View();
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var monitor = await _context.Monitores.Include(m => m.Marca)
            .FirstOrDefaultAsync(m => m.Id == id);

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
            ViewData["MarcaId"] = new SelectList(_context.Marcas, "Id", "Descricao");
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