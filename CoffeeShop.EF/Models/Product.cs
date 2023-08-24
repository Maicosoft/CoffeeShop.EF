﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoffeeShop.EF.Models;

internal class Product
{
    public int ProductId { get; set; }

    public string Name { get; set; } = string.Empty;

    public decimal Price { get; set; }

    public int CategoryId { get; set; }

    public Category Category { get; set; }
    public ICollection<OrderProduct> OrderProducts { get; set; }
}
