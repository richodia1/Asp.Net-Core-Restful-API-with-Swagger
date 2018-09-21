using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicXPro.Domain.BusinessModel;
using LogicXPro.Domain.Interfaces.Managers;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LogicXPro.Controllers
{
    [ApiVersion("1.0")]
    [Produces("application/json")]
    [Route("api/orders")]
    public class OrderController : Controller
    {
        private readonly ILogger _logger;
        private readonly IOrderManager _manager;

        public OrderController(IOrderManager manager, ILogger<OrderController> logger)
        {
            _manager = manager;
            _logger = logger;
        }

        [HttpGet]
        [Route("")]
        [ProducesResponseType(typeof(List<OrderModel>), 200)]
        public async Task<IActionResult> Get()
        {
            _logger.LogInformation("Get All orders Called");
            var orders = await _manager.GetOrdersAsync();
            return Ok(orders);
        }
        /// <summary>
        /// this get the order by user ID
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        [HttpGet]
        [Route("/userId/orders")]
        [ProducesResponseType(typeof(List<OrderModel>), 200)]
        public async Task<IActionResult> Get(int userId)
        {
            _logger.LogInformation("Get order by user ID");
            var orders = await _manager.GetOdersByUserIdAsync(userId);
            return Ok(orders);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [ProducesResponseType(201, Type = typeof(OrderModel))]
        [ProducesResponseType(404)]
        public async Task<IActionResult> Put(int id, [FromBody]  OrderModel order)
        {
            _logger.LogInformation("Update order by id and orderDetail");
            await _manager.UpdateOrderAsync(order);
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }
        /// <summary>
        /// /
        /// </summary>
        /// <param name="order"></param>
        /// <returns></returns>
        [HttpPost]
        [ProducesResponseType(201, Type = typeof(OrderModel))]
        [ProducesResponseType(400)]
        public async Task<IActionResult> Post([FromBody] OrderModel order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _manager.AddOrderAsync(order);
            _logger.LogInformation("Creating order records");
            return CreatedAtAction(nameof(GetOrderById), new { id = order.OrderId }, order);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(OrderModel))]
        [ProducesResponseType(404)]
        public IActionResult GetOrderById(int id)
        {
            var order = _manager.GetOrderByIdAsync(id);

            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }


    }
}