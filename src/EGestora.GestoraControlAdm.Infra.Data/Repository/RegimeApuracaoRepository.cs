using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class RegimeApuracaoRepository : RepositoryBase<RegimeApuracao>, IRegimeApuracaoRepository
    {
        public RegimeApuracaoRepository(EGestoraContext context)
            : base(context)
        {

        }
    }
}
