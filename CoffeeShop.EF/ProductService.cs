using Spectre.Console;

namespace CoffeeShop.EF;

internal class ProductService
{
    internal static void InsertProduct()
    {
        var name = AnsiConsole.Ask<string>("Product's name");
        ProductController.AddProduct(name);
    }
    internal static void GetAllProducts() 
    {
        var products = ProductController.GetProducts();
        UserInterface.ShowProductTable(products);
    }
    internal static void GetProduct() 
    {
        var product = ProductService.GetProductOptionInput();
        UserInterface.ShowProduct(product);
    }
    internal static void UpdateProduct()
    {
        var product = GetProductOptionInput();
        product.Name = AnsiConsole.Ask<string>("Product's new name:");
        ProductController.UpdateProduct(product);
    }
    internal static void DeleteProduct()
    {
        var product = GetProductOptionInput();
        ProductController.DeleteProduct(product);
    }

    static private Product GetProductOptionInput()
    {
        var products = ProductController.GetProducts();
        var productArray = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Product")
            .AddChoices(productArray));
        var id = products.Single(x => x.Name == option).Id;
        var product = ProductController.GetProductById(id);

        return product;
    }
}
