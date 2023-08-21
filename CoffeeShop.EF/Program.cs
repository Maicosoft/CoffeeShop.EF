using Spectre.Console;

var option = AnsiConsole.Prompt(
    new SelectionPrompt<MenuOptions>()
    .Title("What would you like to do?")
    .AddChoices(
        MenuOptions.AddProduct,
        MenuOptions.DeleteProduct,
        MenuOptions.UpdateProduct,
        MenuOptions.ViewProduct,
        MenuOptions.ViewAllProducts,
        MenuOptions.Quit));

enum MenuOptions
{
    AddProduct,
    DeleteProduct,
    UpdateProduct,
    ViewProduct,
    ViewAllProducts,
    Quit
}
