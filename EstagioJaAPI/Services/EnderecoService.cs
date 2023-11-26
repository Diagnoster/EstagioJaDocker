using EstagioJaAPI.Models;
using EstagioJaAPI.Repositories;

namespace EstagioJaAPI.Services;

public class EnderecoService : IEnderecoService
{
    private readonly IEnderecoRepository _enderecoRepository;

    public EnderecoService(IEnderecoRepository enderecoRepository)
    {
        _enderecoRepository = enderecoRepository;
    }

    public Endereco BuscarPorId(int id)
    {
        return _enderecoRepository.BuscarPorId(id);
    }

    public void Inserir(Endereco endereco)
    {
        _enderecoRepository.Inserir(endereco);
    }

    public void Atualizar(Endereco endereco)
    {
        _enderecoRepository.Atualizar(endereco);
    }
}