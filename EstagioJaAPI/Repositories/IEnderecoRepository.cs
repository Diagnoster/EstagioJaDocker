using EstagioJaAPI.Models;

namespace EstagioJaAPI.Repositories;
public interface IEnderecoRepository
{
    public Endereco BuscarPorId(int id);
    public void Inserir(Endereco endereco);
    public void Atualizar(Endereco endereco);
    public void Remover(int id);
}