using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pk.Data;
using Pk.Models;

namespace Majula.Controllers
{
    public class MovimentacoesEquipamentoController : Controller
    {
        private readonly Contexto _context;

        public MovimentacoesEquipamentoController(Contexto context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostMovimentacao([FromBody] MovimentacaoEquipamento movimentacaoEquipamento)
        {

            if (ModelState.IsValid)
            {
                movimentacaoEquipamento.DataAtual = DateTime.Now;
                _context.Add(movimentacaoEquipamento);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Json(movimentacaoEquipamento);
        }
        [HttpGet]
        public IActionResult GetListaMovimentacaoEquipamento(int equipamentoId)
        {
            var movimentacoes = _context.MovimentacoesEquipamento.Where(m => m.EquipamentoId == equipamentoId).OrderByDescending(m => m.DataAtual);
            return Json(movimentacoes);
        }
    }
}