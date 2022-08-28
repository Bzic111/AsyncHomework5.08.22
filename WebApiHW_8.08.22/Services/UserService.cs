﻿using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using WebApiHW_8._08._22.Interfaces.Repository;
using WebApiHW_8._08._22.Interfaces.Service;
using WebApiHW_8._08._22.Interfaces.Validation;
using WebApiHW_8._08._22.Repository.Models;
using WebApiHW_8._08._22.Services.Validation;
//using System.IdentityModel.Tokens;

namespace WebApiHW_8._08._22.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _repository;
    private readonly IUserValidationService _validation;
    public const string SecretCode = "THIS IS SOME VERY SECRET STRING!!! Im blue da ba dee da ba di da ba dee da ba di da d ba dee da ba di da ba dee";
    public UserService(IUserRepository repository, IUserValidationService validation)
    {
        _repository = repository;
        _validation = validation;
    }

    public string Authenticate(string username, string password)
    {
        if (!string.IsNullOrWhiteSpace(username) && !string.IsNullOrWhiteSpace(password))
        {
            var user = _repository.GetAll().Find(u => u.Name == username && u.Password == password);
            if (user is not null)
                return GenerateJwtToken(user.Id);
        }
        return string.Empty;
    }
    private string GenerateJwtToken(int id)
    {
        JwtSecurityTokenHandler tokenHandler = new
        JwtSecurityTokenHandler();
        byte[] key = Encoding.ASCII.GetBytes(SecretCode);
        SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Name, id.ToString())
            }),
            Expires = DateTime.UtcNow.AddMinutes(15),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
    public Task<List<User>> GetAll()
    {
        return Task.Run(() => _repository.GetAll())!;
    }
    public Task<User?> GetById(int id)
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
    public Task<List<User>> GetFilter(Func<User, bool> predicate)
    {
        return Task.Run(() => _repository.GetAll().Where(predicate).ToList());
    }
    public Task<bool> Insert(IEnumerable<User> entities)
    {
        return Task.Run(() => Inserting(entities));

        bool Inserting(IEnumerable<User> clients)
        {
            foreach (var item in clients)
            {
                _repository.Insert(item);
            }
            return true;
        }
    }
    public Task<bool> Insert(User entity)
    {
        return Task.Run(() => _repository.Insert(entity));
    }
    public Task<bool> UpdateOne(User entity)
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
    public IOperationResult CreateUser(User client)
    {
        IReadOnlyList<IOperationFailure> failures = _validation.ValidateEntity(client);
        if (failures.Count==0)
        {
            Insert(client);
        }
        return new OperationResult() { Failures = failures, Succeed = failures.Count == 0 };
    }
}
