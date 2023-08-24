namespace CoffeeShop.EF.Models;

internal class Order
{
    public int Id { get; set; }
    public decimal TotalPrice { get; set; }
    public DateTime CreatedDate { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }

}
