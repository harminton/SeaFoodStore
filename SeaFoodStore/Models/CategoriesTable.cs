using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeaFoodStore.Models;

public partial class CategoriesTable
{
    [Key]
    public int CategoryId { get; set; }

    public string CategoryName { get; set; } = null!;
}
