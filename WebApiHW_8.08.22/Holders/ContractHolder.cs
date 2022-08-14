using WebApiHW_8._08._22.Interfaces;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Holders;

public class ContractHolder : IContractHolder
{
    private List<Contract> _memory { get; set; }
    public ContractHolder()
    {
        _memory = new();
    }

    public bool Create(Contract entity)
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
        _memory.Remove(GetById(id)!);
        return true;
    }

    public IEnumerable<Contract> GetAll() => _memory;

    public Contract? GetById(int id) => _memory.Find(c => c.Id == id);

    public bool Update(Contract entity)
    {
        var t = _memory.Find(x => x.Id == entity.Id);
        _memory[_memory.IndexOf(t!)] = entity;
        return true;
    }

    public int GetCount() => _memory.Count;
}