using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pk.Models
{
    public class Computador
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Esse campo não pode ficar em branco.")]
        public string Tombamento { get; set; }
        public int MarcaId { get; set; }
        public Marca Marca { get; set; }
        public int ModeloId { get; set; }
        public Modelo Modelo { get; set; }
        public int ProcessadorId { get; set; }
        public Processador Processador { get; set; }
        public int MemoriaId { get; set; }
        public Memoria Memoria { get; set; }
        public string ArmazenamentoInterno { get; set; }
        public string Status { get; set; }
        [Display(Name = "Responsável")]
        public string Responsavel { get; set; }
        [Display(Name = "Observação")]
        public string Observacao { get; set; }
        public ICollection<MovimentacaoComputador> MovimentacoesPc { get; set; }

    }
}