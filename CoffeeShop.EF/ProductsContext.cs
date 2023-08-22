using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.EF;

internal class ProductsContext: DbContext
{
    public DbSet<Product> products { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlite($"Data source = product.db");
}
