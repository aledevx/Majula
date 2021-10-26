using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pk.Models
{
    public class EquipamentosVM
    {
        public int QuantImpressora { get; set; }
        public int QuantScanner { get; set; }
        public int QuantSwitch { get; set; }
        public int QuantNobreak { get; set; }
        public int QuantOutros { get; set; }
        public string NomeTipo { get; set; }
    }
}