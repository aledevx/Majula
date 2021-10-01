using System;

namespace Pk.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string Setor { get; set; }
        public DateTime DataAtual { get; set; }
        public bool Ativo { get; set; }
        public int ComputadorId { get; set; }
        public Computador Computador { get; set; }
        public int EquipamentoId { get; set; }
        public Equipamento Equipamento { get; set; }
        public int MonitorId { get; set; }
        public Monitor Monitor { get; set; }
    }
}