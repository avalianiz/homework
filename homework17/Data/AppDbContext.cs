using Microsoft.EntityFrameworkCore;
using homework17.Models;
namespace homework17.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }
    
    public DbSet<Person> Persons => Set<Person>();
    public DbSet<Address> Addresses => Set<Address>();


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Person>()
            .Property(p => p.CreateDate)
            .HasDefaultValueSql("GETUTCDATE()");
    }
}