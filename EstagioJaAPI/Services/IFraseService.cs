using EstagioJaAPI.Models;

namespace EstagioJaAPI.Services;

public interface IFraseService
{
    public FraseEstudante BuscarPorIdEstudante(int id);
    public FraseEmpresa BuscarPorIdEmpresa(int id);
}