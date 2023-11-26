using EstagioJaAPI.Models;

namespace EstagioJaAPI.Services;

public interface IEstudanteService
{
    public Estudante BuscarPorId(int id);
    public Estudante BuscarPorEmail(string email);
    public void Atualizar(Estudante estudante);
    public Estudante BuscarPorIdEstudante(int id);
    public Auth BuscarLoginEstudante(int idEstudante);

}
