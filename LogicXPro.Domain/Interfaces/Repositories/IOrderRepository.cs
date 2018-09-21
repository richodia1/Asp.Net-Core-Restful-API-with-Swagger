using LogicXPro.Domain.BusinessModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Interfaces.Repositories
{
   public interface IOrderRepository
    {
        Task<OrderModel> UpdateOrderAsync(OrderModel model);
        Task<OrderModel> CreateOrderAsync(OrderModel model);
        Task<List<OrderModel>> GetOrdersAsync();
        Task<OrderModel> CancelOrderAsync(int orderId);
        Task<List<OrderModel>> GetOrdersByUserId(int UserId);
        Task<OrderModel> GetOrderByIdAsync(int orderId);
    }
}
