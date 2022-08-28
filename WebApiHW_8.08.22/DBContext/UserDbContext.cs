using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.DBContext;

internal sealed class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=49153;Database=UsersDB;Username=postgres;Password=postgrespw; "); //  postgres://postgres:postgrespw@localhost:49153        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Ignore(x => x.Comment);
    }
}
