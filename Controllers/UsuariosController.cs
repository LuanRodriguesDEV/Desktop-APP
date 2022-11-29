using Microsoft.AspNetCore.Mvc;
using MonowProject.Models;
using MonowProject.Services;

namespace MonowProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class UsuariosController : ControllerBase
    {
        private UsuariosServices _funcionarioService;

        public UsuariosController(UsuariosServices funcionarioService)
        {
            _funcionarioService = funcionarioService;
        }
        [HttpGet]
        public async Task<ActionResult<IAsyncEnumerable<Usuario>>> GetFuncionarios()
        {
            try
            {
                var funcionarios = await _funcionarioService.GetFuncionarios();
                return Ok(funcionarios);
            }
            catch
            {

                return StatusCode(StatusCodes.Status500InternalServerError, "Erro ao obter Funcionarios");
            }
        }
        [HttpGet("{nome}/{senha}", Name = "GetFuncionario")]
        public async Task<ActionResult<Usuario>> GetFuncionario(string nome, string senha)
        {
            try
            {
                var funcionario = await _funcionarioService.GetFuncionario(nome, senha);
                if (funcionario == null)
                    return NotFound("Funcionario não encontrado");
                return Ok(funcionario);
            }
            catch
            {
                return BadRequest("Request Invalido");

            }
        }
        [HttpGet("{id:int}", Name = "GetFuncionarioById")]
        public async Task<ActionResult<Usuario>> GetFuncionarioById(int id)
        {
            try
            {
                var funcionario = await _funcionarioService.GetFuncionarioById(id);
                if (funcionario == null)
                    return NotFound("Funcionario não encontrado");
                return Ok(funcionario);
            }
            catch
            {
                return BadRequest("Request Invalido");

            }
        }
        [HttpPost]
        public async Task<ActionResult> CreateFuncionario (Usuario user)
        {
            await _funcionarioService.CreateFuncionario(user);
            return Ok();
        }
    }
}
