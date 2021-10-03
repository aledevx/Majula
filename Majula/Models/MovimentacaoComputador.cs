using System;

namespace Pk.Models
{
    public class MovimentacaoComputador
    {
        public int Id { get; set; }
        public string Setor { get; set; }
        public DateTime DataAtual { get; set; }
        public bool Ativo { get; set; }
        public int ComputadorId { get; set; }
        public Computador Computador { get; set; }
    }
}