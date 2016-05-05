using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Repository
{
    public interface IEmpresaRepository : IPessoaComplexaRepository<Empresa>
    {
        Empresa GetEmpresaAtiva();
    }
}
