namespace WebApiHW_8._08._22.Interfaces;

public interface IHolder<T> where T : IEntity
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    bool Create(T entity);
    bool Update(T entity);
    bool DeleteById(int id);
    bool DeleteAll();
    int GetCount();

}