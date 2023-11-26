using EstagioJaAPI.Dtos;
using EstagioJaAPI.Models;
using EstagioJaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstagioJaAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FraseController : ControllerBase
    {
        private readonly IFraseService _fraseService;

        public FraseController(IFraseService fraseService)
        {
            _fraseService = fraseService;
        }

        [HttpGet("estudante/{id}")]
        public ActionResult<FraseEstudante> BuscarPorIdEstudante(int id)
        {
            var frase = _fraseService.BuscarPorIdEstudante(id);
            if (frase == null)
            {
                return NotFound();
            }

            return Ok(frase);
        }

        [HttpGet("empresa/{id}")]
        public ActionResult<FraseEmpresa> BuscarPorIdEmpresa(int id)
        {
            var frase = _fraseService.BuscarPorIdEmpresa(id);
            if (frase == null)
            {
                return NotFound();
            }

            return Ok(frase);
        }

    }
}
