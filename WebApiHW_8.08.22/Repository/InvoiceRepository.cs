using WebApiHW_8._08._22.Repository.Models;
using WebApiHW_8._08._22.DBContext;
using WebApiHW_8._08._22.Interfaces;

namespace WebApiHW_8._08._22.Repository;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly CECIDbContext _context;
	public InvoiceRepository(CECIDbContext context)
	{
		_context = context;
	}
    public bool DeleteAll()
    {
        var entityes = _context.Invoices.Where(x => x.IsDeleted == false);
        foreach (var item in entityes)
            item.IsDeleted = true;
        return Commit();
    }

    public bool DeleteById(int id)
    {
        var entity = _context.Invoices.Find(id)!;
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

    public List<Invoice> GetAll()
    {
        return _context.Invoices.Where(x => x.IsDeleted == false).ToList();
    }

    public Invoice? GetById(int id)
    {
        return _context.Invoices.Where(u => u.Id == id).FirstOrDefault();
    }

    public int GetCount()
    {
        return _context.Invoices.Count();
    }

    public bool Insert(Invoice entity)
    {
        _context.Add(entity);
        return Commit();
    }

    public bool UpdateOne(Invoice entity)
    {
        _context.Update(entity);
        return Commit();
    }
}
