using Microsoft.AspNetCore.Mvc;
using MonowProject.Models;
using MonowProject.Services;

namespace MonowProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidosController : ControllerBase
    {
        private PedidosServices _pedidoServices;

        public PedidosController(PedidosServices pedidoServices)
        {
            _pedidoServices = pedidoServices;
        }
        [HttpGet("{id:int}", Name = "GetPedidoById")]
        public async Task<ActionResult<IEnumerable<Pedido>>> GetPedidoById(int id)
        {
            var comandas = await _pedidoServices.GetPedidoComanda(id);
            return Ok(comandas);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePedidoById(int id) {
            await _pedidoServices.DeletePedido(id);
            return Ok();
        }

        [HttpPost]
        public async Task<ActionResult> Create(Pedido pedido)
        {
            await _pedidoServices.CreatePedido(pedido);
            return Ok();
        }
    }
}
