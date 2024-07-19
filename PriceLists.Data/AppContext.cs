using Microsoft.EntityFrameworkCore;
using PriceLists.Data.Models;
using PriceLists.Data.Models.ManyToMany;

namespace PriceLists.Data;

public class AppContext : DbContext
{
    public virtual DbSet<ColumnMtmPriceList> ColumnMtmPriceList { get; set; }

    public virtual DbSet<Column> Columns { get; set; }
    public virtual DbSet<ColumnValue> ColumnValue { get; set; }
    public virtual DbSet<PriceList> PriceLists { get; set; }
    public virtual DbSet<Product> Products { get; set; }

    public AppContext(DbContextOptions<AppContext> options) : base(options) => Database.EnsureCreated();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ColumnMtmPriceList>(entity =>
        {
            entity.HasKey(e => new { e.ColumnId, e.PriceListId });

            entity.HasIndex(e => e.ColumnId);
            entity.HasIndex(e => e.PriceListId);
        });
        
        modelBuilder.Entity<Column>(
            entity => entity.HasMany(e => e.PriceLists).WithMany(e => e.Columns).UsingEntity<ColumnMtmPriceList>());

        modelBuilder.Entity<ColumnValue>(entity =>
        { 
            entity.HasIndex(e => e.ColumnId);
            entity.HasIndex(e => e.PriceListId);
            entity.HasIndex(e => e.ProductId);

            entity.HasOne(e => e.Column).WithMany(e => e.ColumnValues).HasForeignKey(e => e.ColumnId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.PriceList).WithMany(e => e.ColumnValues).HasForeignKey(e => e.PriceListId).OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(e => e.Product).WithMany(e => e.ColumnValues).HasForeignKey(e => e.ProductId).OnDelete(DeleteBehavior.Restrict);
        });

        modelBuilder.Entity<Product>(entity => 
        {
            entity.HasIndex(e => e.PriceListId);
            entity.HasOne(e => e.PriceList).WithMany(e => e.Products).HasForeignKey(e => e.PriceListId).OnDelete(DeleteBehavior.Restrict); 
        });
    }
}
