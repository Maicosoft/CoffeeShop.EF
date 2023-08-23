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
    internal static void DeleteCategory()
    {
        var category = GetCategoryOptionInput();
        CategoryController.DeleteCategory(category);
    }
    internal static void UpdateCategory()
    {
        var category = GetCategoryOptionInput();

        category.Name = AnsiConsole.Confirm("Update Name?") ?
            AnsiConsole.Ask<string>("Category's new name:")
            : category.Name;

        CategoryController.UpdateCategory(category);
    }
    internal static void GetAllCategories()
    {
        var categories = CategoryController.GetCategories();
        UserInterface.ShowCategoryTable(categories);
    }
    internal static Category GetCategoryOptionInput()
    {
        var categories = CategoryController.GetCategories();
        var categoryArray = categories.Select(x => x.Name).ToArray();
        var option = AnsiConsole.Prompt(new SelectionPrompt<string>()
            .Title("Choose Category")
            .AddChoices(categoryArray));
        var category = categories.Single(x => x.Name == option);

        return category;
    }
}
