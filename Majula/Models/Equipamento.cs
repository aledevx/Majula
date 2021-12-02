using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pk.Models
{
    public class Equipamento
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Esse campo não pode ficar em branco.")]
        public string Tombamento { get; set; }
        public string Categoria { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        [Display(Name = "Descrição")]
        public string Descricao { get; set; }
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }
        public string Status { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        [Display(Name = "Movimentações")]
        public ICollection<MovimentacaoEquipamento> MovimentacoesEquipamento { get; set; }
        
    }
}