using Microsoft.AspNetCore.Mvc;
using Phlosales.API.Entities;
using Phlosales.API.Models;
using Phlosales.API.Services;
using System.Net;

namespace Phlosales.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class ProdOrdersController : ControllerBase
    {
        private readonly IProdOrderService prodOrderService;
        private readonly ILogger<ProdOrdersController> logger;

        public ProdOrdersController(IProdOrderService prodOrderService, ILogger<ProdOrdersController> logger)
        {
            this.prodOrderService = prodOrderService ?? throw new ArgumentNullException(nameof(prodOrderService));
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProdOrder>>> GetProdOrders()
        {
            try
            {
                var result = await prodOrderService.GetProdOrders();
                return Ok(result);
            }
            catch (Exception exception)
            {
                logger.LogError(exception.Message);
                return BadRequest(exception);
            }
        }

        [HttpGet("{prodOrderId}")]
        public async Task<ActionResult<ProdOrder>> GetProdOrder(Guid prodOrderId)
        {
            try
            {
                var prodOrder = await prodOrderService.GetProdOrder(prodOrderId);

                if (prodOrder == null)
                {
                    logger.LogError($"Order id: {prodOrderId}, not found!");
                    return NotFound();
                }
                return Ok(prodOrder);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }

        }

        [HttpPost]
        public async Task<ActionResult<ProdOrder>>  CreateProdOrder(ProdOrder prodOrder)
        {
            try
            {
                var result = await prodOrderService.AddProdOrder(prodOrder);
                return Created("prodorders", result);
            }
            catch (Exception exception)
            {
                return BadRequest(exception.Message);
            }
          
        }   
    }
}

