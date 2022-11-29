using Microsoft.AspNetCore.Mvc;
using MonowProject.Models;
using MonowProject.Services;

namespace MonowProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComandasController : ControllerBase
    {
        private ComandasServices _comandasService;

        public ComandasController(ComandasServices comandasService)
        {
            _comandasService = comandasService;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Comanda>>> GetComandas()
        {
            try
            {
                var comandas = await _comandasService.GetComandas();
                return Ok(comandas);
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Funcionarios");
            }
        }

        [HttpGet("{id:int}", Name = "GetComandaById")]
        public async Task<ActionResult<Comanda>> GetComandaById(int id)
        {
            try
            {
                var comandas = await _comandasService.GetComandaById(id);
                if (comandas == null)
                    return NotFound("Comanda não Encontrada");
                return Ok(comandas);
            }
            catch
            {
                return BadRequest("Request Invalido");

            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Comanda comanda)
        {
            try
            {
                await _comandasService.CreateComanda(comanda);
                return CreatedAtRoute(nameof(GetComandaById), new { id = comanda.Id }, comanda);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
