using Microsoft.AspNetCore.Mvc;
using WishList_WebApi.Domains;
using WishList_WebApi.Interfaces;
using WishList_WebApi.Repositories;

namespace WishList_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuariosController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_usuarioRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuario novoUsuario)
        {
            _usuarioRepository.Cadastrar(novoUsuario);

            return StatusCode(201);
        }

        [HttpDelete("{idUsuario}")]
        public IActionResult Deletar(int idUsuario)
        {
            _usuarioRepository.Deletar(idUsuario);
            return StatusCode(204);
        }

        [HttpPut("{idUsuario}")]
        public IActionResult Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            _usuarioRepository.Atualizar(idUsuario, usuarioAtualizado);
            return StatusCode(204);
        }
    }
}
