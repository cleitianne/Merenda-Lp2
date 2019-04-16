using Merenda.DataContext;
using Merenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Repositories
{
    public class AlunoRepository
    {
        private readonly Context _context;

        public AlunoRepository(Context context)
        {
            this._context = context;
        }

        public Aluno GetByMatricula(string matricula){
            var alunos =  _context.Alunos.AsQueryable().Where(a => a.Matricula == matricula).FirstOrDefault();
            return alunos;

        }

        public Aluno GetById (int id)
        {
            return _context.Alunos.Find(id);
        }

        public IQueryable<Aluno> GetAll()
        {
            return _context.Alunos.AsQueryable();
        }

        public Aluno Create(Aluno entity)
        {
            _context.Alunos.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Alunos.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Aluno entity, int id)
        {
            var exist = _context.Alunos.Find(id);
            _context.Entry(exist).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
