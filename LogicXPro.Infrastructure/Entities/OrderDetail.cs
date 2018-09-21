using System;
using System.Collections.Generic;
using System.Text;

namespace LogicXPro.Infrastructure.Entities
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public int CoffeeId { get; set; }
        public int Quantity { get; set; }
        public virtual Coffee Coffee { get; set; }
        public virtual Order Order { get; set; }
    }
}
