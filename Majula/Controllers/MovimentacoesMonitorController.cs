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
    public class MovimentacoesMonitorController : Controller
    {
        private readonly Contexto _context;
        private readonly ServicosMovimentacoes _servicosMovimentacoes;

        public MovimentacoesMonitorController(Contexto context, ServicosMovimentacoes servicosMovimentacoes)
        {
            _context = context;
            _servicosMovimentacoes = servicosMovimentacoes;
        }

        [HttpPost]
        public async Task<IActionResult> PostMovimentacaoMonitor([FromBody] MovimentacaoMonitor movimentacaoMonitor)
        {
            if (ModelState.IsValid)
            {
                _servicosMovimentacoes.DesativarMovMonitor(movimentacaoMonitor.MonitorId);
                movimentacaoMonitor.DataAtual = DateTime.Now;
                _context.Add(movimentacaoMonitor);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Json(movimentacaoMonitor);
        }
        [HttpGet]
        public IActionResult GetListaMovimentacaoMonitor(int id)
        {
            var mov = _context.MovimentacoesMonitor.Include(m => m.Setor).FirstOrDefault(c => c.MonitorId == id && c.Ativo == true);
            return Json(mov);
        }

    }
}