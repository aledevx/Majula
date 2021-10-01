using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pk.Data;
using Pk.Models;

namespace Majula.Controllers
{
    public class MovimentacoesController : Controller
    {
        private readonly Contexto _context;

        public MovimentacoesController(Contexto context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostMovimentacao([FromBody] Movimentacao movimentacao)
        {

            if (ModelState.IsValid)
            {
                movimentacao.DataAtual = DateTime.Now;
                _context.Add(movimentacao);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Json(movimentacao);
        }
        [HttpGet]
        public IActionResult GetListaMovimentacaoPc(int computadorId)
        {
            var movimentacoes = _context.Movimentacoes.Where(m => m.ComputadorId == computadorId).OrderByDescending(m => m.DataAtual);
            return Json(movimentacoes);
        }
        [HttpGet]
        public IActionResult GetListaMovimentacaoMonitor(int monitorId)
        {
            var movimentacoes = _context.Movimentacoes.Where(m => m.MonitorId == monitorId).OrderByDescending(m => m.DataAtual);
            return Json(movimentacoes);
        }
        [HttpGet]
        public IActionResult GetListaMovimentacaoEquipamento(int equipamentoId)
        {
            var movimentacoes = _context.Movimentacoes.Where(m => m.EquipamentoId == equipamentoId).OrderByDescending(m => m.DataAtual);
            return Json(movimentacoes);
        }

    }
}