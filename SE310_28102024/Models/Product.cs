using System;
using System.Collections.Generic;

namespace SE310_28102024.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int Quantity { get; set; }
        public int? CategoryId { get; set; }

        public virtual Category? Category { get; set; }
    }
}
