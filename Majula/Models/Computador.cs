using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pk.Models
{
    public class Computador
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Esse campo não pode ficar em branco.")]
        public string Tombamento { get; set; }
        public string Modelo { get; set; }
        public string Processador { get; set; }
        [Display(Name = "Memória")]
        public string Memoria { get; set; }
        [Display(Name = "Armazenamento interno")]
        public string ArmazenamentoInterno { get; set; }
        public string Status { get; set; }
        public ICollection<Monitor> Monitores { get; set; }
        [Display(Name = "Movimentações")]
        public ICollection<Movimentacao> Movimentacoes { get; set; }
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }
         [Display(Name = "Observação")]
        public string Observacao { get; set; }

    }
}