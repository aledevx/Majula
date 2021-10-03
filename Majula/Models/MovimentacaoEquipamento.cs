using System;

namespace Pk.Models
{
    public class MovimentacaoEquipamento
    {
        public int Id { get; set; }
        public string Setor { get; set; }
        public DateTime DataAtual { get; set; }
        public bool Ativo { get; set; }
        public int EquipamentoId { get; set; }
        public Equipamento Equipamento { get; set; }
    }
}