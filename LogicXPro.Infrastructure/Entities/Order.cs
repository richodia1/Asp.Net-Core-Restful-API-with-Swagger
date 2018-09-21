using System;
using System.Collections.Generic;
using System.Text;

namespace LogicXPro.Infrastructure.Entities
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime StartPreparationTime {get; set;}  
        public bool IsCanceled { get; set; }
        public decimal TotalPrice { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }

        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }
    }
}
