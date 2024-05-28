using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodeCrafters_backend_teamwork.src.DTOs
{

    public class StockReadDto
    {
        public Guid Id { get; set; }

        public Guid ProductId { get; set; }
        public string Size { get; set; }
        public string Color { get; set; }
        public string? Discount { get; }
        public int Quantity { get; set; }

    }
    public class StockCreateDto
    {
        public Guid ProductId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public string Color { get; set; }
        public string? Discount { get; }
    }

}