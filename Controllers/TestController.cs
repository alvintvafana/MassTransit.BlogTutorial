using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace MassTransit.BlogTutorial.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        IBus _bus;
        public TestController(IBus bus)
        {
            _bus = bus;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var endpoint = await _bus.GetSendEndpoint(new Uri("rabbitmq://localhost:15672/submit-order"));
            await endpoint.Send<IAddOrder>(new  { OrderDescription="test order" });
            return Ok();
        }
    }
}
