using WebApiHW_8._08._22.Repository;

namespace WebApiHW_8._08._22.Interfaces;

public interface IRepository<T> where T : class
{
    T? GetById(int id);
    List<T> GetAll();
    bool Insert(T entity);
    bool UpdateOne(T entity);
    bool DeleteById(int id);
    bool DeleteAll();
    public int GetCount();

    //List<T>? GetFilter(Func<T, bool> predicate);
    //bool Insert(IEnumerable<T> entities);
}
