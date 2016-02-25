using EGestora.GestoraControlAdm.Domain.Entities;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Repository
{
    public interface IPessoaRepository<TEntity> : IRepositoryBase<TEntity> where TEntity : class
    {
        TEntity GetByCnpj(string cnpj);
        TEntity GetByCpf(string cpf);
        IEnumerable<PessoaJuridica> GetAllPessoaJuridica();
        IEnumerable<PessoaFisica> GetAllPessoaFisica();
    }
}
