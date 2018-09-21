using System;
using System.Collections.Generic;
using System.Text;

namespace LogicXPro.Domain.BusinessModel
{
   public class OrderDetailModel: Model
    {
        public int OrderDetailId { get; set; }
        public int CoffeeId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual CoffeeModel Coffee { get; set; }
    }
}
