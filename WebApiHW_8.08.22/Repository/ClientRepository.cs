using WebApiHW_8._08._22.Interfaces;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Repository;

public class ClientRepository : IClientRepository
{
    private readonly IClientHolder _holder;
    public ClientRepository(IClientHolder holder)
    {
        _holder = holder;
    }
    public bool Insert(IEnumerable<Client> entities)
    {
        foreach (var item in entities)
            _holder.Create(item);
        return true;
    }

    public bool Insert(Client entity) => _holder.Create(entity);

    public bool DeleteAll() => _holder.DeleteAll();

    public bool DeleteById(int id) => _holder.DeleteById(id);

    public List<Client> GetAll() => _holder.GetAll().ToList();

    public Client? GetById(int id) => _holder.GetById(id);

    public bool UpdateOne(Client entity) => _holder.Update(entity);
    public int GetCount() => _holder.GetCount();
    public List<Client>? GetFilter(Func<Client, bool> predicate) => _holder.GetAll().Where(predicate).ToList();
}
