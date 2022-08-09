using WebApiHW_8._08._22.Entity;
using WebApiHW_8._08._22.Interfaces;

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
        var t = GetById(id)!;
        if (t != null)
            _memory.Remove(t);
        else return false;
        return true;
    }

    public IEnumerable<Contract> GetAll() => _memory;

    public Contract? GetById(int id) => _memory.Find(c => c.Id == id);

    public bool Update(Contract entity)
    {
        var t = _memory.Find(x => x.Id == entity.Id);
        if (t != null)
            _memory[_memory.IndexOf(t)] = entity;
        else return false;
        return true;
    }
}