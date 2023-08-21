﻿using CoffeeShop.EF;
using Spectre.Console;

var isAppRunning = true;
while (isAppRunning)
{
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

    switch (option)
    {
        case MenuOptions.AddProduct:
            ProductController.AddProduct();
            break;
        case MenuOptions.DeleteProduct:
            ProductController.DeleteProduct();
            break;
        case MenuOptions.UpdateProduct:
            ProductController.UpdateProduct();
            break;
        case MenuOptions.ViewProduct:
            ProductController.GetProductById();
            break;
        case MenuOptions.ViewAllProducts:
            ProductController.GetProducts();
            break;
        case MenuOptions.Quit:
            ProductController.Quit();
            break;
    }
}

enum MenuOptions
{
    AddProduct,
    DeleteProduct,
    UpdateProduct,
    ViewProduct,
    ViewAllProducts,
    Quit
}



