using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace CoffeeShop.EF.Models;

[Index(nameof(Name), IsUnique = true)]
internal class Category
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    public List<Product> Products { get; set; }
}
