using System;
using System.Collections.Generic;

namespace EF_Core_Task__.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
