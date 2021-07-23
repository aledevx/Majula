using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pk.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Esse campo não pode ficar em branco.")]
        public string Tombamento { get; set; }
        [Required(ErrorMessage = "Digite a categoria do equipamento.")]
        public string Categoria { get; set; }
        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "Digite a descrição do equipamento.")]
        public string Descricao { get; set; }
        [Required(ErrorMessage = "Digite a origem do equipamento.")]
        public string Origem { get; set; }
        public string Destino { get; set; }
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }
        [Display(Name = "Processo de aquisição")]
        public string ProcessoAquisicao { get; set; }
        public string Cautela { get; set; }
        public string Status { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        [Display(Name = "Movimentações")]
        public ICollection<Movimentacao> Movimentacoes { get; set; }
    }
}