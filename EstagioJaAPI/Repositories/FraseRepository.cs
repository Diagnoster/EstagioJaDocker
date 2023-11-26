using H = NHibernate;
using EstagioJaAPI.Models;
using EstagioJaAPI.Dtos;
using NHibernate.Transform;
using NHibernate;
using System.Collections.Generic;
using EstagioJaAPI.Exceptions;
using System.Transactions;

namespace EstagioJaAPI.Repositories
{
    public class FraseRepository : IFraseRepository
    {
        private readonly H.ISession _session;

        public FraseRepository(H.ISession session)
        {
            _session = session;
        }
        public FraseEstudante BuscarPorIdEstudante(int id)
        {
            return _session.Get<FraseEstudante>(id);
        }

        public FraseEmpresa BuscarPorIdEmpresa(int id)
        {
            return _session.Get<FraseEmpresa>(id);
        }

    }
}
