using System.Linq;
using Merenda.DataContext;
using Merenda.Models;
using Microsoft.EntityFrameworkCore;

namespace Merenda.Repositories
{
    public class AlunoLancheRepository
    {
        private readonly Context _context;

        public AlunoLancheRepository(Context context)
        {
            this._context = context;
        }

        public AlunoLanche GetById (int id)
        {
            return _context.AlunoLanche.Find(id);
        }

        public IQueryable<AlunoLanche> GetAll()
        {
            return _context.AlunoLanche.AsQueryable().Include(al => al.Aluno).Include(al => al.Lanche);
        }

        public AlunoLanche Create(AlunoLanche entity)
        {
            _context.AlunoLanche.Add(entity);
            _context.SaveChanges();
            return entity;
        }

        public void Delete(int id)
        {
            var entity = GetById(id);
            _context.AlunoLanche.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(AlunoLanche entity, int id)
        {
            var exist = _context.AlunoLanche.Find(id);
            _context.Entry(exist).CurrentValues.SetValues(entity);
            _context.SaveChanges();
        }
    }
}