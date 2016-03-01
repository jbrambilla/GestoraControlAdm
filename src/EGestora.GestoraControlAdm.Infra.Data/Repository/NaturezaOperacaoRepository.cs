using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class NaturezaOperacaoRepository : RepositoryBase<NaturezaOperacao>, INaturezaOperacaoRepository
    {
        public NaturezaOperacaoRepository(EGestoraContext context)
            : base(context)
        {

        }
    }
}
