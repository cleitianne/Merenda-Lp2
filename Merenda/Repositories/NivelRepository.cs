using Merenda.DataContext;
using Merenda.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Merenda.Repositories
{
    public class NivelRepository
    {

        private readonly Context _context;

        public NivelRepository(Context context)
        {
            this._context = context;
        }

        public Nivel GetById(int id)
        {
            return _context.Nivels.Find(id);
        }

        public IQueryable<Nivel> GetAll()
        {
            return _context.Nivels.AsQueryable();
        }

        public Nivel Create(Nivel entity)
        {
            _context.Nivels.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.Nivels.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Nivel entity, int id)
        {
            var exist = _context.Nivels.Find(id);
            _context.Entry(exist).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }


    }
}
