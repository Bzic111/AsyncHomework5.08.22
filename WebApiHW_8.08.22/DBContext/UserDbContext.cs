using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.DBContext;

internal sealed class UserDbContext : DbContext
{
    public DbSet<User> Users { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres://postgres:postgrespw@localhost:49153;Database=MyNewDB;Username=postgres;Password=123456; "); //  postgres://postgres:postgrespw@localhost:49153        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>().Ignore(x => x.Comment);
    }
}
public sealed class CECIDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; }
    public DbSet<Employer> Employers { get; set; }
    public DbSet<Contract> Contracts { get; set; }
    public DbSet<Invoice> Invoices { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=postgres://postgres:postgrespw@localhost:49153;Database=CECIDB;Username=postgres;Password=123456;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>();
        modelBuilder.Entity<Employer>();
        modelBuilder.Entity<Contract>();
        modelBuilder.Entity<Invoice>();
    }
}
