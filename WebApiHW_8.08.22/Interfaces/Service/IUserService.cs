using WebApiHW_8._08._22.Interfaces.Validation;
using WebApiHW_8._08._22.Repository.Models;
using WebApiHW_8._08._22.Services.Models;

namespace WebApiHW_8._08._22.Interfaces.Service;

public interface IUserService : IService<User>
{
    string Authenticate(string username, string password);
    IOperationResult CreateUser(User client);

}
