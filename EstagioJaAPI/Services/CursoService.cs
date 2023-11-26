using EstagioJaAPI.Repositories;
using EstagioJaAPI.Models;

namespace EstagioJaAPI.Services;

public class CursoService : ICursoService
{
    private readonly ICursoRepository _cursoRepository;

    public CursoService(ICursoRepository cursoRepository)
    {
        _cursoRepository = cursoRepository;
    }

    public Curso BuscarPorId(int id)
    {
        return _cursoRepository.BuscarPorId(id);
    }

    public void Inserir(Curso curso)
    {
        _cursoRepository.Inserir(curso);
    }

    public void Atualizar(Curso curso)
    {
        _cursoRepository.Atualizar(curso);
    }

    public void Remover(int id)
    {
        var curso = _cursoRepository.BuscarPorId(id);
        if (curso != null)
        {
            _cursoRepository.Remover(curso);
        }
    }

    public IEnumerable<Curso> BuscarTodos()
    {
        return _cursoRepository.BuscarTodos();
    }
}