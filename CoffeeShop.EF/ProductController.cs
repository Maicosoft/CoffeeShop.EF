using Spectre.Console;

namespace CoffeeShop.EF;

internal class ProductController
{
    internal static void AddProduct()
    {
        var name = AnsiConsole.Ask<string>("Product's name");

        using var db = new ProductsContext();
        db.Add(new Product { Name = name });

        db.SaveChanges();
    }

    internal static void DeleteProduct()
    {
        throw new NotImplementedException();
    }

    internal static void GetProductById()
    {
        throw new NotImplementedException();
    }

    internal static void Quit()
    {
        throw new NotImplementedException();
    }

    internal static void UpdateProduct()
    {
        throw new NotImplementedException();
    }

    internal static List<Product> GetProducts()
    {
        using var db = new ProductsContext();

        var products = db.products.ToList();

        return products;
    }
}
