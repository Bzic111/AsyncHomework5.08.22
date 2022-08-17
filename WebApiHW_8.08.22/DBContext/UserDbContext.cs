using Microsoft.EntityFrameworkCore;
using WebApiHW_8._08._22.Interfaces;

namespace WebApiHW_8._08._22.DBContext
{
    internal sealed class UserDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=;Database=MyNewDB;Username=postgres;Password=123456; ");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().Ignore(x => x.Comment);
        }
    }
    internal sealed class ClientDbContext : DbContext
    {

    }
    class User : IPerson
    {
        public string Name { get; set; }
        public int Id { get; set; }
        public string Comment { get; set; }
    }
}
