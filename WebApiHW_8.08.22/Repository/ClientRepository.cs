using WebApiHW_8._08._22.DBContext;
using WebApiHW_8._08._22.Interfaces.Repository;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Repository;

public class ClientRepository : IClientRepository
{
    private readonly CECIDbContext _context;
    public ClientRepository(CECIDbContext context)
    {
        _context = context;
    }

    private bool Commit()
    {
        int count = _context.SaveChanges();
        return count > 0;
    }
    public bool Insert(Client entity)
    {
        _context.Add(entity);
        return Commit();
    }

    public bool DeleteAll()
    {
        var entityes = _context.Clients.Where(x => x.IsDeleted == false);
        foreach (var item in entityes)
        {
            item.IsDeleted = true;
        }
        return Commit();
    }

    public bool DeleteById(int id)
    {
        var entity = _context.Clients.Find(id)!;
        if (entity is not null)
        {
            entity.IsDeleted = true;
            return Commit();
        }
        else return false;
    }
    public List<Client> GetAll() => _context.Clients.Where(x => x.IsDeleted == false).ToList();

    public Client? GetById(int id) => _context.Clients.Where(u => u.Id == id).FirstOrDefault();

    public int GetCount()
    {
        return _context.Clients.Count();
    }

    public bool UpdateOne(Client entity)
    {
        _context.Update(entity);
        return Commit();
    }
}
