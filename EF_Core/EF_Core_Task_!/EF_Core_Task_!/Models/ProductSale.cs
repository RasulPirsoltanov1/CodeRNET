using System;
using System.Collections.Generic;

namespace EF_Core_Task__.Models
{
    public partial class ProductSale
    {
        public int? ProductId { get; set; }
        public string? ProductName { get; set; }
        public DateTime? SaleDate { get; set; }
        public int? Quantity { get; set; }
    }
}
