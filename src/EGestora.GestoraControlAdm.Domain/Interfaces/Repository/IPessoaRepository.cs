using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Repository
{
    public interface IPessoaRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity GetByCnpj(string cnpj);
        TEntity GetByCpf(string cpf);
    }
}
