using WebApiHW_8._08._22.Interfaces.Repository;
using WebApiHW_8._08._22.Interfaces.Service;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Services;

public class EmployerService:IEmployerService
{
    private readonly IEmployerRepository _repository;

    public EmployerService(IEmployerRepository repository)
    {
        _repository = repository;
    }
    public Task<List<Employer>> GetAll()
    {
        return Task.Run(() => _repository.GetAll())!;
    }
    public Task<Employer?> GetById(int id)
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
    public Task<List<Employer>> GetFilter(Func<Employer, bool> predicate)
    {
        return Task.Run(() => _repository.GetAll().Where(predicate).ToList());
    }
    public Task<bool> Insert(IEnumerable<Employer> entities)
    {
        return Task.Run(() => Inserting(entities));

        bool Inserting(IEnumerable<Employer> clients)
        {
            foreach (var item in clients)
            {
                _repository.Insert(item);
            }
            return true;
        }
    }
    public Task<bool> Insert(Employer entity)
    {
        return Task.Run(() => _repository.Insert(entity));
    }
    public Task<bool> UpdateOne(Employer entity)
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