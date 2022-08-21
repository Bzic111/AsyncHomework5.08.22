using Microsoft.EntityFrameworkCore;
using WebApiHW_8._08._22.Repository.Models;

namespace WebApiHW_8._08._22.DBContext;

public sealed class CECIDbContext : DbContext
{
    public DbSet<Client> Clients { get; set; } = null!;
    public DbSet<Employer> Employers { get; set; } = null!;
    public DbSet<Contract> Contracts { get; set; } = null!;
    public DbSet<Invoice> Invoices { get; set; } = null!;

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port:49155;Database=CECIDB;Username=postgres;Password=postgrespw;");
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Client>();
        modelBuilder.Entity<Employer>();
        modelBuilder.Entity<Contract>();
        modelBuilder.Entity<Invoice>();
    }
}
