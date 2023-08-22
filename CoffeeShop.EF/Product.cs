using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.EF;

internal class Product
{
    public int Id { get; set; }
    [Column(TypeName = "varchar(50)")]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "decimal(6,2)")]
    public decimal Price { get; set; }
}
