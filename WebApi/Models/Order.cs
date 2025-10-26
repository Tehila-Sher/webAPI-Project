using System;
using System.Collections.Generic;

namespace WebApi.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public DateTime OrderDate { get; set; }

    public int? UserId { get; set; }

    public decimal TotalAmount { get; set; }

    public virtual User? User { get; set; }
}
