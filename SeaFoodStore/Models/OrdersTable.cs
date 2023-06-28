using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SeaFoodStore.Models;

public partial class OrdersTable
{
    [Key]
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public byte OrderStatus { get; set; }

    public DateTime OrderDate { get; set; }

    public DateTime RequiredDate { get; set; }

    public DateTime? ShippedDate { get; set; }

    public int StoreId { get; set; }

    public int? BrandId { get; set; }
}
