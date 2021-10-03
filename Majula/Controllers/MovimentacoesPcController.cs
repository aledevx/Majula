using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pk.Data;
using Pk.Models;

namespace Majula.Controllers
{
    public class MovimentacoesPcController : Controller
    {
        private readonly Contexto _context;

        public MovimentacoesPcController(Contexto context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostMovimentacao([FromBody] MovimentacaoComputador movimentacaoPc)
        {

            if (ModelState.IsValid)
            {
                movimentacaoPc.DataAtual = DateTime.Now;
                _context.Add(movimentacaoPc);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Json(movimentacaoPc);
        }
        [HttpGet]
        public IActionResult GetListaMovimentacaoPc(int computadorId)
        {
            var movimentacoes = _context.MovimentacoesPc.Where(m => m.ComputadorId == computadorId).OrderByDescending(m => m.DataAtual);
            return Json(movimentacoes);
        }


    }
}