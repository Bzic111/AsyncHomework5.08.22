using WebApiHW_8._08._22.Repository.Models;
using WebApiHW_8._08._22.DBContext;
using WebApiHW_8._08._22.Interfaces.Repository;

namespace WebApiHW_8._08._22.Repository;

public class EmployerRepository : IEmployerRepository
{
    private readonly CECIDbContext _context;
    public EmployerRepository(CECIDbContext context)
    {
        _context = context;
    }
    public bool DeleteAll()
    {
        var entityes = _context.Employers.Where(x => x.IsDeleted == false);
        foreach (var item in entityes)
            item.IsDeleted = true;
        return Commit();
    }

    public bool DeleteById(int id)
    {
        var entity = _context.Employers.Find(id)!;
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

    public List<Employer> GetAll()
    {
        return _context.Employers.Where(x => x.IsDeleted == false).ToList();
    }

    public Employer? GetById(int id)
    {
        return _context.Employers.Where(u => u.Id == id).FirstOrDefault();
    }

    public int GetCount()
    {
        return _context.Employers.Count();
    }

    public bool Insert(Employer entity)
    {
        _context.Add(entity);
        return Commit();
    }

    public bool UpdateOne(Employer entity)
    {
        _context.Update(entity);
        return Commit();
    }
}
