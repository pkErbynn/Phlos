using Microsoft.AspNetCore.Mvc;
using Phlosales.API.Models;
using Phlosales.API.Services;
using System.Net;

namespace Phlosales.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IOrderService orderService;
        private readonly ILogger<OrdersController> logger;

        public OrdersController(IOrderService orderService, ILogger<OrdersController> logger)
        {
            this.orderService = orderService ?? throw new ArgumentNullException(nameof(orderService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> GetAllProducts()
        {
            var result = await orderService.GetOrders();
            return Ok(result);
        } 
    }
}

