using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pk.Models
{
    public class Monitor
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Este campo não pode ficar em branco.")]
        public string Tombamento { get; set; }
        [Required(ErrorMessage = "Digite o modelo do equipamento.")]
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Digite a descrição do equipamento.")]
        public string Descricao { get; set; }
        public int? ComputadorId { get; set; }
        public Computador Computador { get; set; }
        public string Status { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        public ICollection<MovimentacaoMonitor> MovimentacoesMonitor { get; set; }
    }
}