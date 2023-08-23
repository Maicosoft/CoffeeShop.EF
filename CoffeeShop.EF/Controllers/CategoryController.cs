using CoffeeShop.EF.Models;

namespace CoffeeShop.EF.Controllers;

internal class CategoryController
{
    internal static void AddCategory(Category category)
    {
        using var db = new ProductsContext();

        db.Add(category);

        db.SaveChanges();
    }
}
