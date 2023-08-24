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
        var isAppRunning = true;
        while (isAppRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<MainMenuOptions>()
            .Title("What would you like to do?")
            .AddChoices(
                MainMenuOptions.ManageProduct,
                MainMenuOptions.ManageCategories,
                MainMenuOptions.Quit));

            switch (option)
            {
                case MainMenuOptions.ManageProduct:
                    ProductsMenu();
                    break;
                case MainMenuOptions.ManageCategories:
                    CategoriesMenu();
                    break;                
                case MainMenuOptions.Quit:
                    Console.WriteLine("Goodbey");
                    isAppRunning = false;
                    break;
            }
        }
    }

    private static void ProductsMenu()
    {
        var isProductsMenuRunning = true;
        while (isProductsMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
            new SelectionPrompt<ProductMenu>()
            .Title("What would you like to do?")
            .AddChoices(
                ProductMenu.AddProduct,
                ProductMenu.DeleteProduct,
                ProductMenu.UpdateProduct,
                ProductMenu.ViewProduct,
                ProductMenu.ViewAllProducts,
                ProductMenu.GoBack));

            switch (option)
            {
                case ProductMenu.AddProduct:
                    ProductService.InsertProduct();
                    break;
                case ProductMenu.DeleteProduct:
                    ProductService.DeleteProduct();
                    break;
                case ProductMenu.UpdateProduct:
                    ProductService.UpdateProduct();
                    break;
                case ProductMenu.ViewProduct:
                    ProductService.GetProduct();
                    break;
                case ProductMenu.ViewAllProducts:
                    ProductService.GetAllProducts();
                    break;
                case ProductMenu.GoBack:
                    isProductsMenuRunning = false;
                    break;
            }
        }
    }

    private static void CategoriesMenu()
    {
        var isCategoryMenuRunning = true;
        while (isCategoryMenuRunning)
        {
            Console.Clear();
            var option = AnsiConsole.Prompt(
                new SelectionPrompt<CategoryMenu>()
                .Title("What would you like to do?")
                .AddChoices(
                CategoryMenu.AddCategory,
                CategoryMenu.DeleteCategory,
                CategoryMenu.UpdateCategory,
                CategoryMenu.ViewCategory,
                CategoryMenu.ViewAllCategories,
                CategoryMenu.GoBack));

            switch(option)
            {
                case CategoryMenu.AddCategory:
                    CategoryService.InsertCategory();
                    break;
                case CategoryMenu.DeleteCategory:
                    CategoryService.DeleteCategory();
                    break;
                case CategoryMenu.UpdateCategory:
                    CategoryService.UpdateCategory();
                    break;
                case CategoryMenu.ViewCategory:
                    CategoryService.GetCategory();
                    break;
                case CategoryMenu.ViewAllCategories:
                    CategoryService.GetAllCategories();
                    break;
                case CategoryMenu.GoBack:
                    isCategoryMenuRunning = false;
                    break;
            }
        }
    }

    internal static void ShowCategory(Category category)
    {
        var panel = new Panel($@"Id: {category.CategoryId}
Name: {category.Name}
Product Count: {category.Products.Count}")
        {
            Header = new PanelHeader(category.Name),
            Padding = new Padding(2, 2, 2, 2)
        };

        AnsiConsole.Write(panel);

        ShowProductTable(category.Products);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }

    internal static void ShowCategoryTable(List<Category> categories)
    {
        var table = new Table();
        table.AddColumn("Id");
        table.AddColumn("Name");

        foreach (var category in categories)
        {
            table.AddRow(
                category.CategoryId.ToString(),
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
Price: {product.Price}
Category: {product.Category.Name}")        
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
        table.AddColumn("Category");

        foreach (var product in products)
        {
            table.AddRow(
                product.ProductId.ToString(), 
                product.Name, 
                product.Price.ToString(),
                product.Category.Name
                );
        }

        AnsiConsole.Write(table);

        Console.WriteLine("Enter any key to continue");
        Console.ReadLine();
        Console.Clear();
    }
}
