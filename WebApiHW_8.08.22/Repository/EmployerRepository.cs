using WebApiHW_8._08._22.Repository.Models;
using WebApiHW_8._08._22.Interfaces;


namespace WebApiHW_8._08._22.Repository;

public class EmployerRepository:IEmployerRepository
{
    private readonly IEmployerHolder _holder;
    public EmployerRepository(IEmployerHolder holder)
    {
        _holder = holder;
    }
    public bool Insert(IEnumerable<Employer> entities)
    {
        foreach (var item in entities)
            _holder.Create(item);
        return true;
    }
    public bool Insert(Employer entity) => _holder.Create(entity);
    public bool DeleteAll() => _holder.DeleteAll();
    public bool DeleteById(int id) => _holder.DeleteById(id);
    public List<Employer>? GetAll() => _holder.GetAll().ToList();
    public Employer? GetById(int id) => _holder.GetById(id);
    public List<Employer>? GetFilter(Func<Employer, bool> predicate) => _holder.GetAll().Where(predicate).ToList();
    public bool UpdateOne(Employer entity) => _holder.Update(entity);

    public int GetCount() => _holder.GetCount();
}
