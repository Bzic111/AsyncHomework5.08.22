using WebApiHW_8._08._22.Repository;
using WebApiHW_8._08._22.Interfaces;
using WebApiHW_8._08._22.Repository.Models;
using WebApiHW_8._08._22.Controllers;


namespace WebApiHW_8._08._22.Services;

public interface IService<T> where T : class
{
    T? GetById(int id);
    List<T>? GetAll();
    bool Insert(T entity);
    bool UpdateOne(T entity);
    bool DeleteById(int id);
    bool DeleteAll();
    List<T>? GetFilter(Func<T, bool> predicate);
    bool Insert(IEnumerable<T> entities);
}
public interface IClientService : IService<Client>
{

}
public interface IInvoiceService : IService<Invoice>
{

}
public interface IContractService : IService<Contract>
{

}
public interface IEmployerService : IService<Employer>
{

}
public class ClientService : IClientService
{

}
public class InvoiceService :IInvoiceService
{

}
public class ContractService:IContractService
{

}
public class EmployerService:IEmployerService
{

}