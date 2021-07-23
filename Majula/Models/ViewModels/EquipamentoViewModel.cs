using System.Collections.Generic;

namespace Pk.Models.ViewModels
{
    public class EquipamentoViewModel
    {
        public Equipamento Equipamento;
        public ICollection<Movimentacao> Movimentacoes;
    }
}