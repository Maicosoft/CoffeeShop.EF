using CoffeeShop.EF.Controllers;
using CoffeeShop.EF.Models;
using CoffeeShop.EF.Services;
using Spectre.Console;
using static CoffeeShop.EF.Enums;

namespace CoffeeShop.EF;

static internal class UserInterface
{
    static internal void MainMenu()
    {
        var option = AnsiConsole.Prompt(
        new SelectionPrompt<MenuOptions>()
        .Title("What would you like to do?")
        .AddChoices(
            MenuOptions.AddCategory,
            MenuOptions.ViewAllCategories,
            MenuOptions.AddProduct,
            MenuOptions.DeleteProduct,
            MenuOptions.UpdateProduct,
            MenuOptions.ViewProduct,
            MenuOptions.ViewAllProducts,
            MenuOptions.Quit));

        switch (option)
        {
            case MenuOptions.AddCategory:
                CategoryService.InsertCategory();
                break;
            case MenuOptions.ViewAllCategories:
                CategoryService.GetAllCategories(); 
                break;
            case MenuOptions.AddProduct:
                ProductService.InsertProduct();
                break;
            case MenuOptions.DeleteProduct:
                ProductService.DeleteProduct();
                break;
            case MenuOptions.UpdateProduct:
                ProductService.UpdateProduct();
                break;
            case MenuOptions.ViewProduct:
                ProductService.GetProduct();
                break;
            case MenuOptions.ViewAllProducts:
                ProductService.GetAllProducts();
                break;
            case MenuOptions.Quit:
                ProductController.Quit();
                break;
        }
    }

    internal static void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(
                category.Id.ToString(),
                category.Name
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowProduct(Product product)
    {
        var panel = new Panel($@"Id: {product.ProductId}
Name: {product.Name}
Price: {product.Price}")
        {
            Header = new PanelHeader("Product Info"),
            Padding = new Padding(2, 2, 2, 2)
        };

        AnsiConsole.Write(panel);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    static internal void ShowProductTable(List<Product> products)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");
        table.AddColumn("Price");

        foreach (var product in products)
        {
            table.AddRow(
                product.ProductId.ToString(), 
                product.Name, 
                product.Price.ToString()
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }
}
