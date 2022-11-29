using Microsoft.AspNetCore.Mvc;
using MonowProject.Models;
using MonowProject.Services;

namespace MonowProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaixasController : ControllerBase
    {
        private CaixasServices _caixasSerice;
        public CaixasController(CaixasServices caixasSerice)
        {
            _caixasSerice = caixasSerice;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Caixa>>> GetCaixas()
        {
            try
            {
                var caixas = await _caixasSerice.GetCaixas();
                return Ok(caixas);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Caixas");
            }
        }
        [HttpGet("GetCaixa")]
        public async Task<ActionResult<Caixa>> GetCaixa()
        {
            try
            {
                var caixas = await _caixasSerice.GetCaixa();
                return Ok(caixas);
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Caixas");
            }
        }
        [HttpGet("{id:int}", Name = "GetCaixaById")]
        public async Task<ActionResult<Caixa>> GetCaixaById(int id)
        {
            try
            {
                var caixas = await _caixasSerice.GetCaixaById(id);
                if (caixas == null)
                    return NotFound("Caixa não encontrado");
                return Ok(caixas);
            }
            catch
            {

                return BadRequest("Request Invalido");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Caixa caixa)
        {
            try
            {
                await _caixasSerice.CreateCaixa(caixa);
                return CreatedAtRoute(nameof(GetCaixaById), new { id = caixa.Id }, caixa);
            }
            catch
            {
                throw new Exception();

            }
        }
    }
}
