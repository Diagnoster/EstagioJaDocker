using EstagioJaAPI.Models;
using EstagioJaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstagioJaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CompetenciaController : ControllerBase, IController<Competencia>
{

    private readonly ICompetenciaService _competenciaService;

    public CompetenciaController(ICompetenciaService competenciaService)
    {
        _competenciaService = competenciaService;
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar([FromBody] Competencia entidade)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public ActionResult<Competencia> BuscarPorId(int id)
    {
        var competencia = _competenciaService.BuscarPorId(id);

        if (competencia == null)
        {
            return NotFound();
        }

        return Ok(competencia);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Competencia>> BuscarTodos()
    {
        var competencias = _competenciaService.BuscarTodos();
        return Ok(competencias);
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] Competencia comp)
    {
        _competenciaService.Inserir(comp);
        return CreatedAtAction(nameof(BuscarPorId), new { id = comp.id }, comp);  
    }

    [HttpDelete("{id}")]
    public IActionResult Remover(int id)
    {
        throw new NotImplementedException();
    }
}