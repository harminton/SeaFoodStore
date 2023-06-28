using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeaFoodStore.Models;

public partial class ProductTable
{
    [Key]
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    [Range(1, 9, ErrorMessage = "Please enter correct value")]
    public int BrandId { get; set; }

    [Range(1, 6, ErrorMessage = "Please enter correct value")]
    public int CategoryId { get; set; }

    public string Price { get; set; } = null!;

    public string? Discount { get; set; }

    public decimal? Stock { get; set; }
}
