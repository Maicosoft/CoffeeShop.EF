using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.EF.Models;

[Index(nameof(Name), IsUnique = true)]
internal class Product
{
    [Key]
    public int ProductId { get; set; }

    [Column(TypeName = "varchar(50)"), Required]
    public string Name { get; set; } = string.Empty;

    [Column(TypeName = "decimal(6,2)"), Required]
    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    [ForeignKey(nameof(CategoryId))]
    public Category Category { get; set; }
}
