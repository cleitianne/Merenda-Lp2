using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Models
{
    public class Estoque
    {
        public  int Id { get; set; }
        public string Item { get; set; }
        public int COD { get; set; }
        public string Descricao { get; set; }
        public int QtdUtilizada { get; set; }
        public int QtdEstoque { get; set; }
        public double Valor { get; set; }
        public double Total { get; set; }
    }
}
