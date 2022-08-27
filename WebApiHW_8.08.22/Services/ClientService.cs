using WebApiHW_8._08._22.Repository;
using WebApiHW_8._08._22.Repository.Models;
using WebApiHW_8._08._22.Controllers;
using Microsoft.AspNetCore.Mvc;
using WebApiHW_8._08._22.Interfaces.Service;
using WebApiHW_8._08._22.Interfaces.Repository;

namespace WebApiHW_8._08._22.Services;
public class ClientService : IClientService
{
    private readonly IClientRepository _repository;
    public ClientService(IClientRepository repository)
    {
        _repository = repository;
    }

    public Task<List<Client>> GetAll()
    {
        return Task.Run(() => _repository.GetAll())!;
    }
    public Task<Client?> GetById(int id)
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
    public Task<List<Client>> GetFilter(Func<Client, bool> predicate)
    {
        return Task.Run(() => _repository.GetAll().Where(predicate).ToList());
    }
    public Task<bool> Insert(IEnumerable<Client> entities)
    {
        return Task.Run(() => Inserting(entities));

        bool Inserting(IEnumerable<Client> clients)
        {
            foreach (var item in clients)
            {
                _repository.Insert(item);
            }
            return true;
        }
    }
    public Task<bool> Insert(Client entity)
    {
        return Task.Run(() => _repository.Insert(entity));
    }
    public Task<bool> UpdateOne(Client entity)
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
