using WebApiHW_8._08._22.Repository.Models;
using WebApiHW_8._08._22.Interfaces;

namespace WebApiHW_8._08._22.Holders;

public class EmployerHolder : IEmployerHolder
{
    private List<Employer> _memory { get; set; }
    public EmployerHolder()
    {
        _memory = new();
    }
    public bool Create(Employer entity)
    {
        _memory.Add(entity);
        return true;
    }
    public bool DeleteAll()
    {
        _memory = new();
        return true;
    }
    public bool DeleteById(int id)
    {
        var t = GetById(id)!;
        if (t != null)
            _memory.Remove(t);
        else return false;
        return true;
    }
    public IEnumerable<Employer> GetAll() => _memory;
    public Employer? GetById(int id) => _memory.Find(c => c.Id == id);
    public bool Update(Employer entity)
    {
        var t = _memory.Find(x => x.Id == entity.Id);
        if (t != null)
            _memory[_memory.IndexOf(t)] = entity;
        else return false;
        return true;
    }

    public int GetCount() => _memory.Count();
}