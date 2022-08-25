using WebApiHW_8._08._22.Interfaces.Repository;
using WebApiHW_8._08._22.Interfaces.Service;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Services;

public class InvoiceService :IInvoiceService
{
    private readonly IInvoiceRepository _repository;
    public InvoiceService(IInvoiceRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Invoice>> GetAll()
    {
        return Task.Run(() => _repository.GetAll())!;
    }
    public Task<Invoice?> GetById(int id)
    {
        if (_repository.GetCount() > id)
        {
            return Task.Run(() => _repository.GetById(id));
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }
    public Task<List<Invoice>> GetFilter(Func<Invoice, bool> predicate)
    {
        return Task.Run(() => _repository.GetAll().Where(predicate).ToList());
    }
    public Task<bool> Insert(IEnumerable<Invoice> entities)
    {
        return Task.Run(() => Inserting(entities));

        bool Inserting(IEnumerable<Invoice> clients)
        {
            foreach (var item in clients)
            {
                _repository.Insert(item);
            }
            return true;
        }
    }
    public Task<bool> Insert(Invoice entity)
    {
        return Task.Run(() => _repository.Insert(entity));
    }
    public Task<bool> UpdateOne(Invoice entity)
    {
        var ent = GetById(entity.Id);
        if (ent != null)
        {
            return Task.Run(() => _repository.UpdateOne(entity));
        }
        else
        {
            throw new ArgumentException();
        }
    }
    public Task<bool> DeleteAll()
    {
        return Task.Run(() => _repository.DeleteAll());
    }
    public Task<bool> DeleteById(int id)
    {
        if (_repository.GetCount() > id)
        {
            return Task.Run(() => _repository.DeleteById(id));
        }
        else
        {
            throw new ArgumentOutOfRangeException();
        }
    }
}
