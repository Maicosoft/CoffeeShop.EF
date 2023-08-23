using CoffeeShop.EF.Controllers;
using CoffeeShop.EF.Models;
using Spectre.Console;

namespace CoffeeShop.EF.Services;

internal class CategoryService
{
    internal static void InsertCategory()
    {
        var category = new Category();
        category.Name = AnsiConsole.Ask<string>("Category's name:");

        CategoryController.AddCategory(category);
    }
}
