using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Models
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }
        
        //public Curso Curso { get; set; }
       // public int CursoId { get; set; }

    }
}
