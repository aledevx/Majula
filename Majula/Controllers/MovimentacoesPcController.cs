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
                Desativar(movimentacaoPc.ComputadorId);
                movimentacaoPc.DataAtual = DateTime.Now;
                _context.Add(movimentacaoPc);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Json(movimentacaoPc);
        }
        [HttpGet]
        public IActionResult GetListaMovimentacao(int id)
        {
            var mov = _context.MovimentacoesPc.FirstOrDefault(c => c.ComputadorId == id && c.Ativo == true);
            return Json(mov);
        }
        public void Desativar(int computadorId)
        {
            var mov = _context.MovimentacoesPc.FirstOrDefault(c => c.ComputadorId == computadorId && c.Ativo == true);
            if (mov != null)
            {
                mov.Ativo = false;
                _context.Update(mov);
                _context.SaveChanges();
            }

        }

    }
}