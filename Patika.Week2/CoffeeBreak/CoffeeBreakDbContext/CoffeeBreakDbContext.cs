using Microsoft.EntityFrameworkCore;
using CoffeeBreak.Entities;

namespace CoffeeBreak;

public class CoffeeBreakDbContext : DbContext
{
    public CoffeeBreakDbContext(DbContextOptions<CoffeeBreakDbContext> options) : base(options) { }

    public CoffeeBreakDbContext()
    {
    }

    public DbSet<Coffee> Coffees { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(CoffeeBreakDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}