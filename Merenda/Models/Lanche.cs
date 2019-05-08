using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Models
{
    public class Lanche
    {
        public int Id { get; set; }
        public DateTime Dia { get; set; }
        public string Turno { get; set; }
        public int COD_Estoque { get; set; }

        public bool Encerrado { get; set; }
       

    }
}
