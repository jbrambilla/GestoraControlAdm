using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class BoletoRepository : RepositoryBase<Boleto>, IBoletoRepository
    {
        public BoletoRepository(EGestoraContext context)
            :base (context)
        {
        }
    }
}
