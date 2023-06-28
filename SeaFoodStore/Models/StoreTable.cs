using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeaFoodStore.Models;

public partial class StoreTable
{
    [Key]
    public int StoreId { get; set; }

    public string? StoreName { get; set; }
}
