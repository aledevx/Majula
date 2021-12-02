using System.Linq;
using Pk.Data;

namespace Pk.Services
{
    public class ServicosMovimentacoes
    {
        private readonly Contexto _context;

        public ServicosMovimentacoes(Contexto context)
        {
            _context = context;
        }

        public void DesativarMovMonitor(int monitorId)
        {
            var movAtual = _context.MovimentacoesMonitor.FirstOrDefault(c => c.MonitorId == monitorId && c.Ativo == true);
            movAtual.Ativo = false;
            _context.Update(movAtual);
            _context.SaveChanges();
        }
        public void DesativarMovPc(int computadorId)
        {
            var movAtual = _context.MovimentacoesPc.FirstOrDefault(c => c.ComputadorId == computadorId && c.Ativo == true);
            movAtual.Ativo = false;
            _context.Update(movAtual);
            _context.SaveChanges();
        }
        public void DesativarMovEquipamento(int equipamentoId)
        {
            var movAtual = _context.MovimentacoesEquipamento.FirstOrDefault(c => c.EquipamentoId == equipamentoId && c.Ativo == true);
            movAtual.Ativo = false;
            _context.Update(movAtual);
            _context.SaveChanges();
        }
    }
}