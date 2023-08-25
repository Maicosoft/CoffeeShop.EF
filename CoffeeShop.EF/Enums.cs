namespace CoffeeShop.EF;

internal class Enums
{
    internal enum MainMenuOptions
    {
        ManageCategories,
        ManageProduct,
        ManagerOrders,
        Quit
    }
    internal enum ProductMenu
    {       
        AddProduct,
        DeleteProduct,
        UpdateProduct,
        ViewProduct,
        ViewAllProducts,
        GoBack
    }
    internal enum CategoryMenu
    {
        AddCategory,
        DeleteCategory,
        UpdateCategory,
        ViewCategory,
        ViewAllCategories,
        GoBack
    }
    internal enum OrderMenu
    {
        AddOrder,
        GetOrders,
        GetOrder,
        GoBack
    }
}
