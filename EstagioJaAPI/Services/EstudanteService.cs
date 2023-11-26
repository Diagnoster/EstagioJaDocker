using EstagioJaAPI.Models;
using EstagioJaAPI.Repositories;
namespace EstagioJaAPI.Services;

public class EstudanteService : IEstudanteService
{

    private readonly IEstudanteRepository _estudanteRepository;

    public EstudanteService(IEstudanteRepository estudanteRepository)
    {
        _estudanteRepository = estudanteRepository;
    }

    public Estudante BuscarPorEmail(string email)
    {
        return _estudanteRepository.BuscarPorEmail(email);
    }

    public Estudante BuscarPorId(int id)
    {
        return _estudanteRepository.BuscarPorId(id);
    }

    public Estudante BuscarPorIdEstudante(int id)
    {
        return _estudanteRepository.BuscarPorIdEstudante(id);
    }

    public void Atualizar(Estudante estudante) {
        _estudanteRepository.Atualizar(estudante);
    }

    public Auth BuscarLoginEstudante(int idEstudante)
    {
        return _estudanteRepository.BuscarLoginEstudante(idEstudante);
    }

}
