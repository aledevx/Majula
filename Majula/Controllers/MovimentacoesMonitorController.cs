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
        public async Task<IActionResult> PostMovimentacaoMonitor([FromBody] MovimentacaoMonitor movimentacaoMonitor)
        {

            if (ModelState.IsValid)
            {
                // Só funciona a primeira vez se tirar o 'Desativar', pois ele cai no método e ñ volta, 
                //afinal ele é o primeiro da lista dai ñ tem como desativar o proximo
                
                Desativar(movimentacaoMonitor.MonitorId);
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

        public void Desativar(int monitorId)
        {
            var mov = _context.MovimentacoesMonitor.FirstOrDefault(c => c.MonitorId == monitorId && c.Ativo == true);
            mov.Ativo = false;
            _context.Update(mov);
            _context.SaveChanges();
        }
    }
}