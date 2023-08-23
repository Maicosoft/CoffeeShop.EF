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
    internal static void DeleteCategory(Category category)
    {
        using var db = new ProductsContext();

        db.Remove(category);

        db.SaveChanges();
    }
    internal static void UpdateCategory(Category category)
    {
        using var db = new ProductsContext();

        db.Update(category);

        db.SaveChanges();
    }

    internal static List<Category> GetCategories()
    {
        using var db = new ProductsContext();

        var categories = db.Categories.ToList();

        return categories;
    }

    internal static Category GetProductById(int id)
    {
        using var db = new ProductsContext();

        var category = db.Categories.SingleOrDefault(x => x.CategoryId == id);

        return category;
    }
}
