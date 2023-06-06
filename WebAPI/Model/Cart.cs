using System;
using System.Collections.Generic;

namespace WebAPI.Model
{
    public partial class Cart
    {
        public int CartId { get; set; }
        public int UserId { get; set; }
        public int MovieId { get; set; }
        public int Price { get; set; }
        public int Quantity { get; set; }
        public string? Name { get; set; }
    }
}
