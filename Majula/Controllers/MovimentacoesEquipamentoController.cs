using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pk.Data;
using Pk.Models;
using Pk.Services;

namespace Majula.Controllers
{
    public class MovimentacoesEquipamentoController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicosMovimentacoes _servicosMovimentacoes;

        public MovimentacoesEquipamentoController(Contexto context, ServicosMovimentacoes servicosMovimentacoes)
        {
            _context = context;
            _servicosMovimentacoes = servicosMovimentacoes;
        }

        [HttpPost]
        public async Task<IActionResult> PostMovimentacao([FromBody] MovimentacaoEquipamento movimentacaoEquipamento)
        {

            if (ModelState.IsValid)
            {
                _servicosMovimentacoes.DesativarMovEquipamento(movimentacaoEquipamento.EquipamentoId);
                movimentacaoEquipamento.DataAtual = DateTime.Now;
                _context.Add(movimentacaoEquipamento);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Json(movimentacaoEquipamento);
        }
        [HttpGet]
        public IActionResult GetMovimentacaoAtualEquipamento(int id)
        {
            var mov = _context.MovimentacoesEquipamento.Include(m => m.Setor).FirstOrDefault(c => c.EquipamentoId == id && c.Ativo == true);
            return Json(mov);
        }
    }
}