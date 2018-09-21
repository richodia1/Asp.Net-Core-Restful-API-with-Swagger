using LogicXPro.Domain;
using LogicXPro.Domain.BusinessModel;
using LogicXPro.Domain.Interfaces.Repositories;
using LogicXPro.Infrastructure.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogicXPro.Infrastructure.Repositories
{
    public class OrderRepository : IOrderRepository
    {
        private DbContext _context;

        public OrderRepository(DbContext context)
        {
            _context = context;
        }

        public async Task<OrderModel> CancelOrderAsync(int orderId)
        {
            var order = await _context.Set<Order>().Where(o => o.OrderId == orderId).SingleOrDefaultAsync();

            if (order != null)
            {
                order.IsCanceled = true;
            }

            if (_context.Entry(order).State == EntityState.Detached)
            {
                _context.Set<Order>().Attach(order);
            }

            _context.Entry(order).State = EntityState.Modified;

            return new OrderModel().Assign(order);
        }

        public async Task<List<OrderModel>> GetOrdersByUserId(int UserId)
        {
            var orders = await _context.Set<Order>()
                                        .Include(o => o.OrderDetails)
                                         .ThenInclude(c => c.Coffee)
                                         .Where(o => o.Customer.UserID == UserId).ToListAsync();
            return orders.Select(o => new OrderModel().Assign(o)).ToList();
        }

        public async Task<OrderModel> CreateOrderAsync(OrderModel model)
        {
            var customer = await _context.Set<Customer>().Where(c => c.UserID == model.UserId).SingleOrDefaultAsync();

            var newOrder = new Order
            {
                OrderDate = DateTime.Now,
                IsCanceled = true,
                TotalPrice = model.TotalPrice,
                StartPreparationTime = model.PickupTime,
                Customer = customer,
            };

            var orderDetail = new OrderDetail();
            orderDetail.CoffeeId = model.CoffeeId;
            orderDetail.Order = newOrder;
            orderDetail.Quantity = model.Quantity;

            await _context.AddAsync(newOrder);
            await _context.AddAsync(orderDetail);
            await _context.SaveChangesAsync();

            return new OrderModel().Assign(newOrder);
        }

        public async Task<List<OrderModel>> GetOrdersAsync()
        {
            var orders = await _context.Set<Order>()
                                 .Include(o => o.OrderDetails)
                                     .ThenInclude(c => c.Coffee).ToListAsync();

            return orders.Select(o => new OrderModel().Assign(o)).ToList();
        }

        public async Task<OrderModel> UpdateOrderAsync(OrderModel model)
        {
            var order = await _context.Set<Order>().Where(o => o.OrderId == model.OrderId).SingleOrDefaultAsync();

            order.Assign(model);

            if (order != null)
            {
                if (_context.Entry(order).State == EntityState.Detached)
                {
                    _context.Set<Order>().Attach(order);
                }
                _context.Entry(order).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }

            return new OrderModel().Assign(order);
        }

        public async Task<OrderModel> GetOrderByIdAsync(int orderId)
        {
            var order = await _context.Set<Order>().Where(o => o.OrderId == orderId).SingleOrDefaultAsync();

            return new OrderModel().Assign(order);
        }
    }
}
