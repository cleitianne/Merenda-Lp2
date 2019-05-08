using Merenda.DataContext;
using Merenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Repositories
{
    public class LancheRepository
    {
        private readonly Context _context;

        public LancheRepository(Context context)
        {
            this._context = context;
        }

        public Lanche GetById(int id)
        {
            return _context.Lanche.Find(id);
        }

        public IQueryable<Lanche> GetAll()
        {
            return _context.Lanche.AsQueryable();
        }

        public Lanche Create(Lanche entity)
        {
            _context.Lanche.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Lanche.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Lanche entity, int id)
        {
            var exist = _context.Lanche.Find(id);
            _context.Entry(exist).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }

        public Lanche GetLancheAtual()
        {
            return _context.Lanche.AsQueryable().Where(e => e.Encerrado==false).FirstOrDefault();
        }
    }
}
