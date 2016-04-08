using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Repository
{
    public interface ICodigoSegurancaRepository : IRepositoryBase<CodigoSeguranca>
    {
        void GerarCodigo(CodigoSeguranca codigoSeguranca);
    }
}
