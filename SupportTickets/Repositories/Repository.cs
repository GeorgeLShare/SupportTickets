using Microsoft.EntityFrameworkCore;
using SupportTickets.Interfaces;
using SupportTickets.Models.Database;

namespace SupportTickets.Repositories
{
    public abstract class Repository<T> : IRepository<T> where T : class
    {
        protected readonly SupportTicketContext _context;

        protected void Save() => _context.SaveChanges();

        public Repository(SupportTicketContext context)
        {
            _context = context;
        }

        public void Create(T entity)
        {
            _context.Add(entity);
            Save();
        }

        public void Create(T[] entities)
        {
            _context.AddRange(entities);
            Save();
        }

        public void Delete(T entity)
        {
            _context.Remove(entity);
            Save();
        }

        public T GetById(int id)
        {
            return _context.Set<T>().Find(id);
        }


        public IQueryable<T> GetAll()
        {
            return _context.Set<T>().AsQueryable();
        }


        public IQueryable<T> FindWithId(Func<T, bool> Id)
        {
            return _context.Set<T>().Where(Id).AsQueryable();
        }

        public void Update(T entity)
        {
            _context.Update(entity).State = EntityState.Modified;
            Save();
        }
    }
}
