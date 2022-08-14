using WebApiHW_8._08._22.Repository.Models;
using WebApiHW_8._08._22.Interfaces;


namespace WebApiHW_8._08._22.Repository;

public class InvoiceRepository : IInvoiceRepository
{
    private readonly IInvoiceHolder _holder;
    public InvoiceRepository(IInvoiceHolder holder)
    {
        _holder = holder;
    }
    public bool Insert(IEnumerable<Invoice> entities)
    {
        foreach (var item in entities)
            _holder.Create(item);
        return true;
    }
    public bool Insert(Invoice entity)=> _holder.Create(entity);
    public bool DeleteAll() => _holder.DeleteAll();
    public bool DeleteById(int id) => _holder.DeleteById(id);
    public List<Invoice> GetAll() => _holder.GetAll().ToList();
    public Invoice? GetById(int id) => _holder.GetById(id);
    public List<Invoice>? GetFilter(Func<Invoice, bool> predicate) => _holder.GetAll().Where(predicate).ToList();
    public bool UpdateOne(Invoice entity) => _holder.Update(entity);
    public int GetCount() => _holder.GetCount();
}
