using EstagioJaAPI.Models;

namespace EstagioJaAPI.Services;

public interface IEnderecoService {
    public Endereco BuscarPorId(int id);
    public void Inserir(Endereco endereco);
    public void Atualizar(Endereco endereco);
}