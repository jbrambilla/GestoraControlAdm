using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class NotaServicoRepository : RepositoryBase<NotaServico>, INotaServicoRepository
    {
        public NotaServicoRepository(EGestoraContext context)
            : base(context)
        {

        }
    }
}
