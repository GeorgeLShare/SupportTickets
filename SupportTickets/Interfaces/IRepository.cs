namespace SupportTickets.Interfaces
{
    public interface IRepository<T> where T : class
    {
        T GetById(int id);

        IQueryable<T> GetAll();

        void Create(T entity);

        void Create(T[] entities);

        void Update(T entity);

        void Delete(T entity);

        IQueryable<T> FindWithId(Func<T, bool> Id);
    }
}
