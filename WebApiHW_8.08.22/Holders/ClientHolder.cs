using WebApiHW_8._08._22.Interfaces;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Holders;

public class ClientHolder : IClientHolder
{
    private List<Client> _memory { get; set; }
    public ClientHolder()
    {
        _memory = new();
    }
    public bool Create(Client entity)
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
    public IEnumerable<Client> GetAll() => _memory;
    public Client? GetById(int id) => _memory.Find(c => c.Id == id);
    public bool Update(Client entity)
    {
        var t = _memory.Find(x => x.Id == entity.Id);
        if (t != null)
            _memory[_memory.IndexOf(t)] = entity;
        else return false;
        return true;
    }
}
