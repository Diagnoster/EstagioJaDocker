using EstagioJaAPI.Repositories;
using EstagioJaAPI.Models;
using EstagioJaAPI.Dtos;
using EstagioJaAPI.Exceptions;

namespace EstagioJaAPI.Services;

public class VagaService : IVagaService
{
    private readonly IVagaRepository _vagaRepository;

    public VagaService(IVagaRepository vagaRepository)
    {
        _vagaRepository = vagaRepository;
    }

    public Vaga BuscarPorId(int id)
    {
        return _vagaRepository.BuscarPorId(id);
    }

    public IEnumerable<Vaga> BuscarVagasPorIdLoginEmpresa(int id)
    {
        return _vagaRepository.BuscarVagasPorIdLoginEmpresa(id);
    }

    public IEnumerable<Vaga> BuscarVagasFinalizadasPorIdLoginEmpresa(int id)
    {
        return _vagaRepository.BuscarVagasFinalizadasPorIdLoginEmpresa(id);
    }

    public void Inserir(Vaga vaga)
    {
        _vagaRepository.Inserir(vaga);
    }

    public void Atualizar(Vaga vaga)
    {
        _vagaRepository.Atualizar(vaga);
    }

    public void Remover(int id)
    {
        var vaga = _vagaRepository.BuscarPorId(id);
        if (vaga != null)
        {
            _vagaRepository.Remover(vaga);
        }
    }

    public IEnumerable<Vaga> BuscarTodos()
    {
        return _vagaRepository.BuscarTodos();
    }

    public void Candidatar(CandidaturaDto candidatura)
    {
        _vagaRepository.Candidatar(candidatura);
    }

    public IEnumerable<Estudante> BuscarCandidatos(int idVaga)
    {
        try
        {
            return _vagaRepository.BuscarCandidatos(idVaga);
        }
        catch (RegistroNaoEncontradoException e)
        {
            throw e;
        }
    }

    public void AprovarCandidato(CandidaturaDto candidatura)
    {
        _vagaRepository.AprovarCandidato(candidatura);
    }

    public void RejeitarCandidato(CandidaturaDto candidatura)
    {
        _vagaRepository.RejeitarCandidato(candidatura);
    }

    public void finalizarVaga(int id)
    {
        _vagaRepository.finalizarVaga(id);
    }

}
