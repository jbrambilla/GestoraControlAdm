using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class AuditActionRepository : RepositoryBase<AuditAction>, IAuditActionRepository
    {
        public AuditActionRepository(EGestoraContext context)
            :base (context)
        {

        }
    }
}
