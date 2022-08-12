using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.Interfaces;

public interface IEntity
{
    public int Id { get; set; }
}
public interface IClientHolder : IHolder<Client>
{

}
public interface IContractHolder : IHolder<Contract>
{

}
public interface IEmployerHolder : IHolder<Employer>
{

}
public interface IInvoiceHolder : IHolder<Invoice>
{

}
public interface IHolder<T> where T : IEntity
{
    IEnumerable<T> GetAll();
    T? GetById(int id);
    bool Create(T entity);
    bool Update(T entity);
    bool DeleteById(int id);
    bool DeleteAll();
}