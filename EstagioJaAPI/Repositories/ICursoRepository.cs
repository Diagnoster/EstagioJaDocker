using EstagioJaAPI.Models;

namespace EstagioJaAPI.Repositories;
public interface ICursoRepository
{
    public IEnumerable<Curso> BuscarTodos();
    public Curso BuscarPorId(int id);
    public void Inserir(Curso curso);
    public void Atualizar(Curso curso);
    public void Remover(Curso curso);
}