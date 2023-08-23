using CoffeeShop.EF.Models;
using Microsoft.EntityFrameworkCore;

namespace CoffeeShop.EF;

internal class ProductsContext: DbContext
{
    public DbSet<Product> Products { get; set; }
    public DbSet<Category> Categories { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
        optionsBuilder.UseSqlServer(@"Data Source=(localDB)\ MSSQLLocalDB;Initial Catalog=CoffeeShop.EF;Integrated Security=True;");
}
