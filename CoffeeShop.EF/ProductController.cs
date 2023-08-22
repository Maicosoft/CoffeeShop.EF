using Spectre.Console;

namespace CoffeeShop.EF;

internal class ProductController
{
    internal static void AddProduct(Product product)
    {  
        using var db = new ProductsContext();
        db.Add(product);

        db.SaveChanges();
    }

    internal static void DeleteProduct(Product product)
    {
        using var db = new ProductsContext();
        db.Remove(product);
        db.SaveChanges();
    }

    internal static Product GetProductById(int id)
    {
        using var db = new ProductsContext();
        var product = db.products.SingleOrDefault(x => x.Id == id);

        return product;
    }

    internal static void Quit()
    {
        throw new NotImplementedException();
    }

    internal static void UpdateProduct(Product product)
    {
        using var db = new ProductsContext();
        db.Update(product);
        db.SaveChanges();
    }

    internal static List<Product> GetProducts()
    {
        using var db = new ProductsContext();

        var products = db.products.ToList();

        return products;
    }
}
