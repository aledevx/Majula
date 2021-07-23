using System.Collections.Generic;

namespace Pk.Models.ViewModels
{
    public class ComputadorViewModel
    {
        public Computador Computador;
        public ICollection<Movimentacao> Movimentacoes;
        public ICollection<Monitor> Monitores;
    }
}