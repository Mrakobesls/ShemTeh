using System.Linq;

namespace ShemTeh.Data.Repositories
{
    public interface IGenericRepository<T>
    {
        void Create(T entity);
        T Read(int Id);
        IQueryable<T> ReadAll();
        void Update(T entity);
        void Delete(int id);

    }
}
