using EstagioJaAPI.Models;

namespace EstagioJaAPI.Repositories
{
    public interface IFraseRepository
    {
        public FraseEstudante BuscarPorIdEstudante(int id);
        public FraseEmpresa BuscarPorIdEmpresa(int id);
    }
}
