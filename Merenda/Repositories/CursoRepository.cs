using Merenda.DataContext;
using Merenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Repositories
{
    public class CursoRepository
    {

        private readonly Context _context;

        public CursoRepository(Context context)
        {
            this._context = context;
        }

        public Curso GetById(int id)
        {
            return _context.Cursos.Find(id);
        }

        public IQueryable<Curso> GetAll()
        {
            return _context.Cursos.AsQueryable();
        }

        public Curso Create(Curso entity)
        {
            _context.Cursos.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Cursos.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Curso entity, int id)
        {
            var exist = _context.Cursos.Find(id);
            _context.Entry(exist).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

    }
}
