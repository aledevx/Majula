using System;

namespace Pk.Models
{
    public class Movimentacao
    {
        public int Id { get; set; }
        public string Setor { get; set; }
        public DateTime DataAtual { get; set; }
        public int EntidadeId { get; set; }
    }
}