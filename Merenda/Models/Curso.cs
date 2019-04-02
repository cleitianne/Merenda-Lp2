using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Models
{
    public class Curso
    {
        public Curso()
        {
           // Alunos = new HashSet<Aluno>();
        }
        public int Id { get; set; }
        public int NivelId { get; set; }
        public string Nome { get; set; }
        public Nivel Nivel { get; set; }
       // public ICollection<Aluno> Alunos { get; set; }
    }
}
