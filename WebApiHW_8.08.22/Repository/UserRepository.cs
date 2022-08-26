using WebApiHW_8._08._22.DBContext;
using WebApiHW_8._08._22.Repository.Models;
using System.Linq;
using WebApiHW_8._08._22.Interfaces.Repository;

namespace WebApiHW_8._08._22.Repository;

internal sealed class UserRepository : IUserRepository
{
    private readonly UserDbContext _context;
    public UserRepository(UserDbContext context)
    {
        _context = context;
    }

    public bool DeleteAll()
    {
        var entityes = _context.Users.Where(x => x.IsDeleted == false);
        foreach (var item in entityes)
        {
            item.IsDeleted = true;
        }
        return Commit();
    }

    public bool DeleteById(int id)
    {
        var entity = _context.Users.Find(id)!;
        if (entity is not null)
        {
            entity.IsDeleted = true;
            return Commit();
        }
        else return false;
    }

    private bool Commit()
    {
        int count = _context.SaveChanges();
        return count > 0;
    }

    public List<User> GetAll()
    {
        return _context.Users.Where(x => x.IsDeleted == false).ToList();
    }

    public User? GetById(int id)
    {
        return _context.Users.Where(u => u.Id == id).FirstOrDefault();
    }

    public int GetCount()
    {
        return _context.Users.Count();
    }

    public bool Insert(User entity)
    {
        _context.Add(entity);
        return Commit();
    }

    public bool UpdateOne(User entity)
    {
        _context.Update(entity);
        return Commit();
    }

    public User Find(string username)
    {
        return _context.Users.FirstOrDefault(u => u.IsDeleted == false & u.Name == username)!;
    }
}