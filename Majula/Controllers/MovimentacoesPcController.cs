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
            try
            {
                if (ModelState.IsValid)
                {

                    _servicosMovimentacoes.DesativarMovPc(movimentacaoPc.ComputadorId);
                    movimentacaoPc.DataAtual = DateTime.Now;
                    _context.Add(movimentacaoPc);
                    await _context.SaveChangesAsync();

                    var monitores = _context.Monitores.Where(m => m.ComputadorId == movimentacaoPc.ComputadorId).ToList();

                    if (monitores.Count == 0)
                    {
                        return Ok();
                    }
                    else
                    {
                        foreach (var item in monitores)
                        {
                            _servicosMovimentacoes.DesativarMovMonitor(item.Id);
                            MovimentacaoMonitor movMonitor = new MovimentacaoMonitor();
                            movMonitor.MonitorId = item.Id;
                            movMonitor.Ativo = true;
                            movMonitor.DataAtual = DateTime.Now;
                            movMonitor.SetorId = movimentacaoPc.SetorId;
                            _context.Add(movMonitor);
                            await _context.SaveChangesAsync();
                        }
                    }

                    return Ok();
                }
            }
            catch (System.Exception mensagem)
            {

                throw new Exception("Error ", mensagem);
            }

            return Json(movimentacaoPc);
        }
        [HttpGet]
        public IActionResult GetMovimentacaoAtualPc(int id)
        {
            var mov = _context.MovimentacoesPc.Include(m => m.Setor).FirstOrDefault(c => c.ComputadorId == id && c.Ativo == true);
            return Json(mov);
        }
    }
}