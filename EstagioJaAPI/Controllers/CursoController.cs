using EstagioJaAPI.Models;
using EstagioJaAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstagioJaAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class CursoController : ControllerBase, IController<Curso>
{

    private readonly ICursoService _cursoService;

    public CursoController(ICursoService cursoService)
    {
        _cursoService = cursoService;
    }

    [HttpPut("{id}")]
    public IActionResult Atualizar([FromBody] Curso entidade)
    {
        throw new NotImplementedException();
    }

    [HttpGet("{id}")]
    public ActionResult<Curso> BuscarPorId(int id)
    {
        var curso = _cursoService.BuscarPorId(id);

        if (curso == null)
        {
            return NotFound();
        }

        return Ok(curso);
    }

    [HttpGet]
    public ActionResult<IEnumerable<Curso>> BuscarTodos()
    {
        var cursos = _cursoService.BuscarTodos();
        return Ok(cursos);
    }

    [HttpPost]
    public IActionResult Inserir([FromBody] Curso curso)
    {
        _cursoService.Inserir(curso);
        return CreatedAtAction(nameof(BuscarPorId), new { id = curso.id }, curso);
    }

    [HttpDelete("{id}")]
    public IActionResult Remover(int id)
    {
        throw new NotImplementedException();
    }
}