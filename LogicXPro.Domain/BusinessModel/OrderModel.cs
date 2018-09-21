using System;
using System.Collections.Generic;
using System.Text;

namespace LogicXPro.Domain.BusinessModel
{
    public class OrderModel : Model
    {
        public int OrderId { get; set; }
        public int UserId { get; set; }
        public int CoffeeId { get; set; }
        public int Quantity { get; set; }
        public DateTime PickupTime { get; set; }
        //public double UserLatitude { get; set; }
       // public double UserLongitude { get; set; }
       // public double CoffeeShopLatitude { get; set; }
       // public double CoffeeShopLongitude { get; set;}
        public decimal TotalPrice { get; set; }
        public bool IsCanceled { get; set; }
        public List<OrderDetailModel> OrderDetail { get; set; }
    }
}
