using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System;
using System.Linq;
using EGestora.GestoraControlAdm.Infra.Data.Context;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class ClienteRepository : RepositoryBase<Cliente>, IClienteRepository
    {
        public ClienteRepository(EGestoraContext context)
            : base(context)
        {

        }

        public Cliente GetByCnpj(string cnpj)
        {
            return Search(c => c.PessoaJuridica.Cnpj == cnpj).FirstOrDefault();
        }
    }
}
