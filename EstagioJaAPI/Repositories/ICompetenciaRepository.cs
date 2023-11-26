using EstagioJaAPI.Models;

namespace EstagioJaAPI.Repositories;
public interface ICompetenciaRepository
{
    public IEnumerable<Competencia> BuscarTodos();
    public Competencia BuscarPorId(int id);
    public void Inserir(Competencia competencia);
    public void Atualizar(Competencia competencia);
    public void Remover(Competencia competencia);
}