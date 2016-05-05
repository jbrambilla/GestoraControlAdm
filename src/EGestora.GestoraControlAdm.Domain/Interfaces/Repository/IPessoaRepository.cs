using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Repository
{
    public interface IPessoaRepository : IRepositoryBase<Pessoa>
    {
        Pessoa GetByCnpj(string cnpj);
        Pessoa GetByCpf(string cpf);
    }
}
