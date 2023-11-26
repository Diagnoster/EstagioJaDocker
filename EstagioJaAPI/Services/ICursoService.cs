using EstagioJaAPI.Models;

namespace EstagioJaAPI.Services;

public interface ICursoService {
    public IEnumerable<Curso> BuscarTodos();
    public Curso BuscarPorId(int id);
    public void Inserir(Curso curso);
    public void Atualizar(Curso curso);
    public void Remover(int id);
}