using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TEST.Models;

namespace TEST.Controllers
{
    [Route("orders")]
    [ApiController]
    public class DefaultController : ControllerBase
    {
        IRepository Repository;

        public DefaultController(IRepository repository)
        {
            Repository = repository;
        }

        [HttpGet]
        public ActionResult<List<Order.response>> Get([FromQuery]OrderParameters parameters)
        {
            var orders = Repository.GET(parameters);

            if (orders.Count == 0)
            {
                return NoContent();
            }

            return Ok(orders);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order.response>> Get(string id)
        {
            var order = await Repository.GET(id);

            if (order == null)
                return NotFound(new Error { code = 135, message = "Order not found", details = "Cannot find order with id: " + id});
            
            return Ok(order);
        }

        [HttpPost]
        public ActionResult<Order.response> Post(Order.request order)
        {
            if (typeof(Order.request) != order.GetType())
            {
                return UnprocessableEntity(new Error { code = 1050 , message = "Invalid data", details = "nvalid location field in incoming object" });
            }

            Repository.POST(order);

            return Created("Create!!!", order);
        }
    }
}
