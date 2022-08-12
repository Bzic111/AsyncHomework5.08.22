using WebApiHW_8._08._22.Interfaces;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Repository;

public class ContractRepository:IContractRepository
{
    private readonly IContractHolder _holder;
    public ContractRepository(IContractHolder holder)
    {
        _holder = holder;
    }
    public bool Insert(IEnumerable<Contract> entities)
    {
        foreach (var item in entities)
            _holder.Create(item);
        return true;
    }
    public bool Insert(Contract entity) => _holder.Create(entity);
    public bool DeleteAll() => _holder.DeleteAll();
    public bool DeleteById(int id) => _holder.DeleteById(id);
    public List<Contract>? GetAll() => _holder.GetAll().ToList();
    public Contract? GetById(int id) => _holder.GetById(id);
    public List<Contract>? GetFilter(Func<Contract, bool> predicate) => _holder.GetAll().Where(predicate).ToList();
    public bool UpdateOne(Contract entity) => _holder.Update(entity);
}
