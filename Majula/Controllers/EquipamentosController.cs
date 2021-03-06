using System;
using System.Collections.Generic;
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

        public IActionResult Index(string searchString)
        {

            var equipamentos = _context.Equipamentos.Include(e => e.Marca);
            List<Equipamento> equipamentos2 = equipamentos.ToList();

            if (!String.IsNullOrEmpty(searchString))
            {
                equipamentos2 = equipamentos2.Where(e => e.Tombamento.Contains(searchString)).ToList();

                if (equipamentos2.Count >= 1)
                {
                    ViewBag.equipamentoNaoEncontrado = false;
                }
                else
                {
                    ViewBag.equipamentoNaoEncontrado = true;
                }
            }

            return View(equipamentos2);
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
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Add(equipamento);
                    await _context.SaveChangesAsync();
                    var setorGTI = _context.Setores.Where(setor => setor.Sigla == "GTI").FirstOrDefault();
                    MovimentacaoEquipamento movEquipamento = new MovimentacaoEquipamento();
                    movEquipamento.EquipamentoId = equipamento.Id;
                    movEquipamento.SetorId = setorGTI.Id;
                    movEquipamento.DataAtual = DateTime.Now;
                    movEquipamento.Ativo = true;
                    _context.Add(movEquipamento);
                    await _context.SaveChangesAsync();

                    return RedirectToAction("Detalhes", "Equipamentos", new { id = equipamento.Id });
                }
            }
            catch (System.Exception mensagem)
            {

                throw new Exception("Error ", mensagem);
            }

            return View();
        }

        public async Task<IActionResult> Detalhes(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = await _context.Equipamentos.Include(e => e.MovimentacoesEquipamento)
            .Include(e => e.Marca).FirstOrDefaultAsync(e => e.Id == id);

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
            ViewBag.Status = _geradorListas.ListaStatus();
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
                return RedirectToAction("Detalhes", "Equipamentos", new { id = equipamento.Id });
            }
            return View();
        }

        public IActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var equipamento = _context.Equipamentos.Find(id);

            if (equipamento == null)
            {
                return NotFound();
            }

            return View(equipamento);
        }
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> ConfirmarExclussao(Equipamento equipamento)
        {
            if (ModelState.IsValid)
            {
                _context.Remove(equipamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View();
        }

        public async Task<JsonResult> Dados()
        {
            var equipamento = _context.Equipamentos.GroupBy(p => p.Categoria)
                   .Select(g => new { name = g.Key, count = g.Count() });

            return Json(await equipamento.ToListAsync());
        }
    }
}