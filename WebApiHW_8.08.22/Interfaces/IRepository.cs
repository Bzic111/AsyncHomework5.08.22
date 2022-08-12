using WebApiHW_8._08._22.Repository;

namespace WebApiHW_8._08._22.Interfaces;

public interface IRepository<T> where T : class
{
    T? GetById(int id);
    List<T>? GetAll();
    List<T>? GetFilter(Func<T, bool> predicate);
    bool Insert(T entity);
    bool Insert(IEnumerable<T> entities);
    bool UpdateOne(T entity);
    bool DeleteById(int id);
    bool DeleteAll();
}
