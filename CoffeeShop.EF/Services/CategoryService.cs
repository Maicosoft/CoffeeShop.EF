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

    internal static void GetAllCategories()
    {
        var categories = CategoryController.GetCategories();
        UserInterface.ShowCategoryTable(categories);
    }
    internal static int GetCategoryOptionInput()
    {
        var categories = CategoryController.GetCategories();
        var categoryArray = categories.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Category")
            .AddChoices(categoryArray));
        var id = categories.Single(x => x.Name == option).CategoryId;

        return id;
    }
}
