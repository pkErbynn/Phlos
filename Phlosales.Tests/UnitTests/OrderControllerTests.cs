using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using Phlosales.API.Controllers;
using Phlosales.API.Entities;
using Phlosales.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Phlosales.Tests.UnitTests
{
    public class OrderControllerTests
    {
        private readonly Mock<IProdOrderService> mockOrderService;
        private readonly Mock<ILogger<ProdOrdersController>> logger;

        public OrderControllerTests()
        {
            mockOrderService = new Mock<IProdOrderService>(); 
            logger = new Mock<ILogger<ProdOrdersController>>();
        }

        [Fact]
        public async void GetProdOrders_Success()
        {
            var mockOrder = new List<ProdOrder>
            {
                Mock.Of<ProdOrder>(order => order.CustomerName == "c1" && order.ProductName == "p1" && order.Price == 1),
                Mock.Of<ProdOrder>(order => order.CustomerName == "c2" && order.ProductName == "p2" && order.Price == 2)
            };
            mockOrderService.Setup(s => s.GetProdOrders()).ReturnsAsync(mockOrder);
            var proOrderController = new ProdOrdersController(mockOrderService.Object, logger.Object);

            var result = await proOrderController.GetProdOrders();
            var actual = result.Result;

            Assert.NotNull(result);
            Assert.IsType<OkObjectResult>(result.Result);
            mockOrderService.Verify();
        }

        [Fact]
        public async void GetProdOrders_BadRequest()
        {
            mockOrderService.Setup(s => s.GetProdOrders()).Throws(() => (new ArgumentException()));
            var proOrderController = new ProdOrdersController(mockOrderService.Object, logger.Object);

            var result = await proOrderController.GetProdOrders();

            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async void GetProdOrder_Success()
        {
            var mockProdOrderId = Guid.NewGuid();
            var expectedProdOrder = Mock.Of<ProdOrder>(order => 
                order.ProdOrderId == mockProdOrderId && 
                order.CustomerName == "c1" && 
                order.ProductName == "p1" && order.Price == 1);

            mockOrderService.Setup(s => s.GetProdOrder(It.IsAny<Guid>())).ReturnsAsync(expectedProdOrder);

            var proOrderController = new ProdOrdersController(mockOrderService.Object, logger.Object);

            var actual = await proOrderController.GetProdOrder(mockProdOrderId);
            var actualResult = (OkObjectResult)actual.Result;
            var actualValue= (ProdOrder)actualResult.Value;

            Assert.IsType<OkObjectResult>(actualResult);
            Assert.Equal(mockProdOrderId, actualValue.ProdOrderId);
        }

        [Fact]
        public async void GetProdOrder_NotFound()
        {
            var invalidProdOrderId = Guid.NewGuid();
            mockOrderService.Setup(s => s.GetProdOrder(It.IsAny<Guid>())).Returns(Task.FromResult<ProdOrder>(null));

            var proOrderController = new ProdOrdersController(mockOrderService.Object, logger.Object);

            var actual = await proOrderController.GetProdOrder(invalidProdOrderId);

            Assert.IsType<NotFoundResult>(actual.Result);
        }
    }
}
