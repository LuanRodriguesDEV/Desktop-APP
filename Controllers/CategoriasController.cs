using Microsoft.AspNetCore.Mvc;
using MonowProject.Models;
using MonowProject.Services;

namespace MonowProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        private CategoriasServices _categoriasService;

        public CategoriasController(CategoriasServices comandasService)
        {
            _categoriasService = comandasService;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Categoria>>> GetCategorias()
        {
            try
            {
                var comandas = await _categoriasService.GetCategorias();
                return Ok(comandas);
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Funcionarios");
            }
        }
        [HttpPost]
        public async Task<ActionResult> Create(Categoria comanda)
        {
            try
            {
                await _categoriasService.CreateCategoria(comanda);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
