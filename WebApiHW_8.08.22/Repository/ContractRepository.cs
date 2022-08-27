using WebApiHW_8._08._22.DBContext;
using WebApiHW_8._08._22.Interfaces.Repository;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Repository;

public class ContractRepository : IContractRepository
{
    private readonly CECIDbContext _context;
    public ContractRepository(CECIDbContext context)
    {
        _context = context;
    }

    public bool DeleteAll()
    {
        var entityes = _context.Contracts.Where(x => x.IsDeleted == false);
        foreach (var item in entityes)
        {
            item.IsDeleted = true;
        }
        return Commit();
    }

    public bool DeleteById(int id)
    {
        var entity = _context.Contracts.Find(id)!;
        if (entity is not null)
        {
            entity.IsDeleted = true;
            return Commit();
        }
        else return false;
    }

    private bool Commit()
    {
        int count = _context.SaveChanges();
        return count > 0;
    }

    public List<Contract> GetAll()
    {
        return _context.Contracts.Where(x => x.IsDeleted == false).ToList();
    }

    public Contract? GetById(int id)
    {
        return _context.Contracts.Where(u => u.Id == id).FirstOrDefault();
    }

    public int GetCount()
    {
        return _context.Contracts.Count();
    }

    public bool Insert(Contract entity)
    {
        _context.Add(entity);
        return Commit();
    }

    public bool UpdateOne(Contract entity)
    {
        _context.Update(entity);
        return Commit();
    }
}