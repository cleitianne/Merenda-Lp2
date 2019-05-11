using Merenda.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.DataContext
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options) : base(options)
        { }

        public Context()
        {
        }
        //As entidades que o Entity Framework gerencia;
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Nivel> Nivels { get; set; }
        public DbSet<Estoque> Estoque { get; set; }
        public DbSet<Lanche> Lanche { get; set; }
        public DbSet<AlunoLanche> AlunoLanche { get; set; }
    }
}
