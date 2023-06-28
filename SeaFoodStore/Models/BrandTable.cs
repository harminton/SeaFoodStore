using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeaFoodStore.Models;

public partial class BrandTable
{
    [Key]
    public int BrandId { get; set; }

    public string? BrandName { get; set; }
}
