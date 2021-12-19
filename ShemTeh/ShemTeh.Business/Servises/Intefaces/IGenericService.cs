namespace ShemTeh.Business.Servises
{
    public interface IGenericService<T>
    {
        int Add(T entity);
        T Read(int id);
        List<T> ReadAll();
        void Delete(int id);
        void Update(T entity);
    }
}
