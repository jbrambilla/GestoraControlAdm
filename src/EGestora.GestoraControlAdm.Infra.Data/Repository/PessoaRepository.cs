using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System.Linq;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class PessoaRepository : RepositoryBase<Pessoa>, IPessoaRepository
    {
        public PessoaRepository(EGestoraContext context)
            :base (context)
        {

        }

        public Pessoa GetByCnpj(string cnpj)
        {
            return Search(c => c.PessoaJuridica.Cnpj == cnpj).FirstOrDefault();
        }

        public Pessoa GetByCpf(string cpf)
        {
            return Search(c => c.PessoaFisica.Cpf == cpf).FirstOrDefault();
        }
    }
}
