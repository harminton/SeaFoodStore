using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeaFoodStore.Models;

public partial class StockTable
{
    [Key]
    public int StockId { get; set; }

    public int? ProductId { get; set; }

    public int? StoreId { get; set; }

    public int? Quantity { get; set; }
}
