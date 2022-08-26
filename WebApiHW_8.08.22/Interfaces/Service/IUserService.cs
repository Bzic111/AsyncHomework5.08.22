using WebApiHW_8._08._22.Repository.Models;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using WebApiHW_8._08._22.Services.Models;

namespace WebApiHW_8._08._22.Interfaces.Service;

public interface IUserService : IService<User>
{
    TokenResponse Authenticate(string user, string password);
}
