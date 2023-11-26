using EstagioJaAPI.Repositories;
using EstagioJaAPI.Models;

namespace EstagioJaAPI.Services;

public class CompetenciaService : ICompetenciaService
{
    private readonly ICompetenciaRepository _competenciaRepository;

    public CompetenciaService(ICompetenciaRepository competenciaRepository)
    {
        _competenciaRepository = competenciaRepository;
    }

    public Competencia BuscarPorId(int id)
    {
        return _competenciaRepository.BuscarPorId(id);
    }

    public void Inserir(Competencia competencia)
    {
        _competenciaRepository.Inserir(competencia);
    }

    public void Atualizar(Competencia competencia)
    {
        _competenciaRepository.Atualizar(competencia);
    }

    public void Remover(int id)
    {
        var competencia = _competenciaRepository.BuscarPorId(id);
        if (competencia != null)
        {
            _competenciaRepository.Remover(competencia);
        }
    }

    public IEnumerable<Competencia> BuscarTodos()
    {
        return _competenciaRepository.BuscarTodos();
    }
}