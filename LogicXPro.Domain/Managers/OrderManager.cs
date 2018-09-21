using LogicXPro.Domain.BusinessModel;
using LogicXPro.Domain.Interfaces.DataAccess;
using LogicXPro.Domain.Interfaces.Managers;
using LogicXPro.Domain.Interfaces.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Domain.Managers
{
    public class OrderManager : IOrderManager
    {
        private readonly IUserManager _usermanager;

        private readonly IOrderRepository _orderRepository;
        private readonly ICoffeeRepository _CoffeeRepository;
        public OrderManager(IUserManager userManager, IOrderRepository repo)
        {
            _usermanager = userManager;
            _orderRepository = repo;
        }

        public async Task<OrderModel> CancelOrdersAsync(int id)
        {
            var order = await _orderRepository.CancelOrderAsync(id);
            return order;
        }

        public async Task<OrderModel> AddOrderAsync(OrderModel model)
        {
            var cofffee = await _CoffeeRepository.GetCoffeeByIdAsync(model.CoffeeId);
            model.PickupTime = model.PickupTime.AddMinutes(cofffee.PreparationTime);
            var order = await _orderRepository.CreateOrderAsync(model);
            return order;
        }

        public async Task<List<OrderModel>> GetOdersByUserIdAsync(int userId)
        {
            var orders =  await _orderRepository.GetOrdersByUserId(userId);
            return orders;
        }

        public async Task<List<OrderModel>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return orders;
        }

        public async Task<OrderModel> UpdateOrderAsync(OrderModel model)
        {
            var order = await _orderRepository.UpdateOrderAsync(model);
            return order;
        }

        public async Task<OrderModel> GetOrderByIdAsync(int orderId)
        {
            var order = await _orderRepository.GetOrderByIdAsync(orderId);
            return order;
        }
    }
}
