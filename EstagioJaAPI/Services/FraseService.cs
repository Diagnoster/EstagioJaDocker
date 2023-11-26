using EstagioJaAPI.Repositories;
using EstagioJaAPI.Models;
using EstagioJaAPI.Dtos;
using EstagioJaAPI.Exceptions;

namespace EstagioJaAPI.Services
{
    public class FraseService : IFraseService
    {
        private readonly IFraseRepository _fraseRepository;
        public FraseService(IFraseRepository fraseRepository) 
        {
            _fraseRepository = fraseRepository;
        }

        public FraseEstudante BuscarPorIdEstudante(int id)
        {
            return _fraseRepository.BuscarPorIdEstudante(id);
        }
        public FraseEmpresa BuscarPorIdEmpresa(int id)
        {
            return _fraseRepository.BuscarPorIdEmpresa(id);
        }
    }
}
