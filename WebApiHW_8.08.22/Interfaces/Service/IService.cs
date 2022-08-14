namespace WebApiHW_8._08._22.Interfaces;

public interface IService<T> where T : class
{
    Task<T?> GetById(int id);
    Task<List<T>> GetAll();
    Task<bool> Insert(T entity);
    Task<bool> UpdateOne(T entity);
    Task<bool> DeleteById(int id);
    Task<bool> DeleteAll();
    Task<List<T>> GetFilter(Func<T, bool> predicate);
    Task<bool> Insert(IEnumerable<T> entities);
}
