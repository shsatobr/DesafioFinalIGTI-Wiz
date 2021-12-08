using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DesafioFinalIGTIWiz.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public Autor Autor { get; set; }                    // Deefinição para FK
        public int AutorId { get; set; }
        public string Descricao { get; set; }
        public int ISBN { get; set; }
        public int AnoLancamento { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
