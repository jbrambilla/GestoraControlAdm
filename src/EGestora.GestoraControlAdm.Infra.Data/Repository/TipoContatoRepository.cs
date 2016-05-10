using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class TipoContatoRepository : RepositoryBase<TipoContato>, ITipoContatoRepository
    {
        public TipoContatoRepository(EGestoraContext context)
            :base (context)
        {

        }
    }
}
