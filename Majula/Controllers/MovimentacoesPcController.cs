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
    public class MovimentacoesPcController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicosMovimentacoes _servicosMovimentacoes;

        public MovimentacoesPcController(Contexto context, ServicosMovimentacoes servicosMovimentacoes)
        {
            _context = context;
            _servicosMovimentacoes = servicosMovimentacoes;
        }
        [HttpPost]
        public async Task<IActionResult> PostMovimentacao([FromBody] MovimentacaoComputador movimentacaoPc)
        {
            if (ModelState.IsValid)
            {
                _servicosMovimentacoes.DesativarMovPc(movimentacaoPc.ComputadorId);
                movimentacaoPc.DataAtual = DateTime.Now;
                _context.Add(movimentacaoPc);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Json(movimentacaoPc);
        }
        [HttpGet]
        public IActionResult GetListaMovimentacaoPc(int id)
        {
            var mov = _context.MovimentacoesPc.Include(m => m.Setor).FirstOrDefault(c => c.ComputadorId == id && c.Ativo == true);
            return Json(mov);
        }
    }
}