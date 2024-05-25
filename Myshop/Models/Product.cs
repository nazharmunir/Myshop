using System;
using System.Collections.Generic;

namespace Myshop.Models
{
    public partial class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Image { get; set; }
        public string? Description { get; set; }
        public int Price { get; set; }
        public int? Discount { get; set; }
    }
}
