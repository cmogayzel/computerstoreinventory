using Microsoft.EntityFrameworkCore;
using ComputerStoreInventory.Models;

namespace ComputerStoreInventory.Data;

public class InventoryContext : DbContext
{
    public InventoryContext(DbContextOptions<InventoryContext> options) : base(options)
    {
    }

    public DbSet<InventoryItem> InventoryItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<InventoryItem>()
            .Property(i => i.Price)
            .HasPrecision(18, 2);
        modelBuilder.Entity<InventoryItem>()
            .Property(i => i.ScreenSize)
            .HasPrecision(5, 2);
    }
}
