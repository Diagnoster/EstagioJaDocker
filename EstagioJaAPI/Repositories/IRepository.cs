namespace EstagioJaAPI.Repositories;

public interface IRepository<T> {
    public IEnumerable<T> BuscarTodos();
    public T BuscarPorId(int id);
    public void Inserir(T entidade);
    public void Atualizar(T entidade);
    public void Remover(T entidade);
}