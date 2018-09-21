using LogicXPro.Domain.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Interfaces.Managers
{
   public interface IOrderManager
    {
        Task<OrderModel> AddOrderAsync(OrderModel model);
        Task<List<OrderModel>> GetOrdersAsync();
        Task<List<OrderModel>> GetOdersByUserIdAsync(int customerId);
        Task<OrderModel> CancelOrdersAsync(int id);
        Task<OrderModel> UpdateOrderAsync(OrderModel model);
        Task<OrderModel> GetOrderByIdAsync(int orderId);
    }
}
