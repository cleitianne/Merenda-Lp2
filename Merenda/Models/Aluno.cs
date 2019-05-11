using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Models
{   //Estrutura do Banco de Dados
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Matricula { get; set; }
        public string Curso { get; set; }

        public string Nivel { get; set; }
        
        //public Curso Curso { get; set; }
       // public int CursoId { get; set; }

    }
}
