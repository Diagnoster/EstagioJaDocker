using EstagioJaAPI.Models;

namespace EstagioJaAPI.Repositories;
public interface IEstudanteRepository
{
    public Estudante BuscarPorId(int id);
    public Estudante BuscarPorEmail(string email);
    public void Atualizar(Estudante estudante);
    public Estudante BuscarPorIdEstudante(int id);
    public Auth BuscarLoginEstudante(int idEstudante);

}