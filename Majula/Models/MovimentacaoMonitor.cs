using System;

namespace Pk.Models
{
    public class MovimentacaoMonitor
    {
        public int Id { get; set; }
        public string Setor { get; set; }
        public DateTime DataAtual { get; set; }
        public bool Ativo { get; set; }
        public int MonitorId { get; set; }
        public Monitor Monitor { get; set; }
    }
}