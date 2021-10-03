using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pk.Data;
using Pk.Models;

namespace Majula.Controllers
{
    public class MovimentacoesMonitorController : Controller
    {
        private readonly Contexto _context;

        public MovimentacoesMonitorController(Contexto context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> PostMovimentacao([FromBody] MovimentacaoMonitor movimentacaoMonitor)
        {

            if (ModelState.IsValid)
            {
                movimentacaoMonitor.DataAtual = DateTime.Now;
                _context.Add(movimentacaoMonitor);
                await _context.SaveChangesAsync();
                return Ok();
            }
            return Json(movimentacaoMonitor);
        }
        [HttpGet]
        public IActionResult GetListaMovimentacaoMonitor(int monitorId)
        {
            var movimentacoes = _context.MovimentacoesMonitor.Where(m => m.MonitorId == monitorId).OrderByDescending(m => m.DataAtual);
            return Json(movimentacoes);
        }
    }
}