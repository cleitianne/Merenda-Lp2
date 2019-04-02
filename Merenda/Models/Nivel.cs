using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Models
{
    public class Nivel
    {
        public Nivel()
        {
            Cursos = new HashSet<Curso>();
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Curso> Cursos { get; set; }
        
    }
}
