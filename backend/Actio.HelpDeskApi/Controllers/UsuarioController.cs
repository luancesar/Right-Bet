using Actio.HelpDeskApi.Models;
using Actio.HelpDeskApi.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Actio.HelpDeskApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost("autenticar")]
        public async Task<ActionResult> Autenticar(LoginModel model)
        {
            var resposta = await _usuarioService.AutenticarUsuario(model.Login, model.Senha);

            return Ok(resposta);
        }

        [HttpPost("registrar")]
        public async Task<ActionResult> Registrar(UserModel user)
        {
            var resposta = await _usuarioService.RegistrarUsuario(user);

            return Ok(resposta);
        }

        [HttpGet()]
        public async Task<ActionResult> Get()
        {
            var resposta = await _usuarioService.ObterUsuarios();

            return Ok(resposta);
        }

        [HttpPost("delete")]
        public async Task<ActionResult> Delete(UserModel user)
        {
            var resposta = await _usuarioService.DeleteUser(user.Id);

            return Ok(resposta);
        }

        [HttpGet("report")]
        public async Task<ActionResult> GetReport()
        {
            var resposta = await _usuarioService.GetReportModel();

            return Ok(resposta);
        }

    }
}
