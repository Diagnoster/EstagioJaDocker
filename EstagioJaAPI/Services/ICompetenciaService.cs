using EstagioJaAPI.Models;

namespace EstagioJaAPI.Services;

public interface ICompetenciaService {
    public IEnumerable<Competencia> BuscarTodos();
    public Competencia BuscarPorId(int id);
    public void Inserir(Competencia competencia);
    public void Atualizar(Competencia competencia);
    public void Remover(int id);
}