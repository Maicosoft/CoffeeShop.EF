using CoffeeShop.EF.Controllers;
using CoffeeShop.EF.Models;
using Spectre.Console;

namespace CoffeeShop.EF.Services;

internal class ProductService
{
    internal static void InsertProduct()
    {
        Product product = new()
        {
            Name = AnsiConsole.Ask<string>("Product's name"),
            Price = AnsiConsole.Ask<decimal>("Product's price"),
            CategoryId = CategoryService.GetCategoryOptionInput().CategoryId
        };

        ProductController.AddProduct(product);
    }
    internal static void GetAllProducts()
    {
        var products = ProductController.GetProducts();
        UserInterface.ShowProductTable(products);
    }
    internal static void GetProduct()
    {
        var product = GetProductOptionInput();
        UserInterface.ShowProduct(product);
    }
    internal static void UpdateProduct()
    {
        var product = GetProductOptionInput();

        product.Name = AnsiConsole.Confirm("Update Name?") ?
            AnsiConsole.Ask<string>("Product's new name:")
            : product.Name;
        product.Price = AnsiConsole.Confirm("Update Price?") ?
            AnsiConsole.Ask<decimal>("Product's new price:")
            : product.Price;
        product.Category = AnsiConsole.Confirm("Update Category?") ?
            CategoryService.GetCategoryOptionInput()
            : product.Category;

        ProductController.UpdateProduct(product);
    }
    internal static void DeleteProduct()
    {
        var product = GetProductOptionInput();
        ProductController.DeleteProduct(product);
    }

    internal static Product GetProductOptionInput()
    {
        var products = ProductController.GetProducts();
        var productArray = products.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Product")
            .AddChoices(productArray));
        var id = products.Single(x => x.Name == option).ProductId;
        var product = ProductController.GetProductById(id);

        return product;
    }
}
