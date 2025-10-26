﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public int? CategoryId { get; set; }

    public string? Description { get; set; }

    public decimal Price { get; set; }

    public int StockQuantity { get; set; }

    public string? ImageSrc { get; set; }

    public virtual Category? Category { get; set; }
}
