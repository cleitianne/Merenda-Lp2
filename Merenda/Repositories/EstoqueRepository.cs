using Merenda.DataContext;
using Merenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Repositories
{
    public class EstoqueRepository
    {
        private readonly Context _context;

        public EstoqueRepository(Context context)
        {
            this._context = context;
        }

        public Estoque GetById(int id)
        {
            return _context.Estoque.Find(id);
        }

        public IQueryable<Estoque> GetAll()
        {
            return _context.Estoque.AsQueryable();
        }

        public Estoque Create(Estoque entity)
        {
            _context.Estoque.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Estoque.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Estoque entity, int id)
        {
            var exist = _context.Estoque.Find(id);
            _context.Entry(exist).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}
