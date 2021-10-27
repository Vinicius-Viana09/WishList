using Microsoft.AspNetCore.Mvc;
using WishList_WebApi.Domains;
using WishList_WebApi.Interfaces;
using WishList_WebApi.Repositories;

namespace WishList_WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class DesejosController : ControllerBase
    {
        private IDesejoRepository _desejoRepository { get; set; }

        public DesejosController()
        {
            _desejoRepository = new DesejoRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_desejoRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Desejo novoDesejo)
        {
            _desejoRepository.Cadastrar(novoDesejo);

            return StatusCode(201);
        }

        [HttpDelete("{idDesejo}")]
        public IActionResult Deletar(int idDesejo)
        {
            _desejoRepository.Deletar(idDesejo);
            return StatusCode(204);
        }

        [HttpPut("{idDesejo}")]
        public IActionResult Atualizar(int idDesejo, Desejo desejoAtualizado)
        {
            _desejoRepository.Atualizar(idDesejo, desejoAtualizado);
            return StatusCode(204);
        }
    }
}
