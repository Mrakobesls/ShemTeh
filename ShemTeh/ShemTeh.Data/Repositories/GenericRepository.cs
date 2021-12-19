namespace ShemTeh.Data.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T>
        where T : class
    {
        private readonly StDbContext _dbContext;

        public GenericRepository(StDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Create(T entity)
        {
            _dbContext.Add(entity);
        }

        public T Read(int id)
        {
            return _dbContext.Find<T>(id);
        }

        public IQueryable<T> ReadAll()
        {
            return _dbContext.Set<T>();
        }

        public IQueryable<T> ReadAlld()
        {
            return _dbContext.Set<T>();
        }

        public void Update(T entity)
        {
            _dbContext.Update(entity);
        }

        public void Delete(int id)
        {
            _dbContext.Remove(id);
        }
    }
}
