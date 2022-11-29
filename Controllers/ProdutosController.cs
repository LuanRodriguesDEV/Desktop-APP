using Microsoft.AspNetCore.Mvc;
using MonowProject.Models;
using MonowProject.Services;

namespace MonowProject.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private ProdutosServices _produtosService;

        public ProdutosController(ProdutosServices produtosService)
        {
            _produtosService = produtosService;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Produto>>> GetProdutos()
        {
            try
            {
                var comandas = await _produtosService.GetProdutos();
                return Ok(comandas);
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Produtos");
            }
        }
        [HttpGet("{id:int}", Name = "GetProdutoById")]
        public async Task<ActionResult<Usuario>> GetProdutosById(int id)
        {
            try
            {
                var produto = await _produtosService.GetProdutoById(id);
               
                return Ok(produto);
            }
            catch
            {
                return BadRequest("Request Invalido");

            }
        }
        [HttpGet("{nome}")]
        public async Task<ActionResult<IEnumerable<Usuario>>> GetProdutosByName(string nome)
        {
            try
            {
                var produto = await _produtosService.GetProdutoByName(nome);
                if (produto == null)
                    return NotFound("Produto não encontrado");
                return Ok(produto);
            }
            catch
            {
                return BadRequest("Request Invalido");

            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Produto produto)
        {

            await _produtosService.CreateProduto(produto);
            return Ok();

        }
    }
}
