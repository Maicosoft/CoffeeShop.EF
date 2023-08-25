﻿namespace CoffeeShop.EF.Models.DTOs;

internal class ProductsForOrderViewDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string CategoryName { get; set; }
    public int Quantity { get; set; }
    public decimal Price { get; set; }
    public decimal TotalPrice { get; set; }
}

