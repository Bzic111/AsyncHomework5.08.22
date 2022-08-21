namespace WebApiHW_8._08._22.Interfaces.Repository;

public interface IRepository<T> where T : class
{
    T? GetById(int id);
    List<T> GetAll();
    bool Insert(T entity);
    bool UpdateOne(T entity);
    bool DeleteById(int id);
    bool DeleteAll();
    public int GetCount();
}