using Microsoft.AspNetCore.Mvc;

namespace Fatec.Store.Orders.Api.Controllers
{
    [Route("api/v1/orders")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        public OrdersController() { }

        [HttpGet]
        public async Task<IActionResult> Metodo()
        {
            return Ok();
        }
    }
}
