using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using System;
using System.Linq;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System.Collections.Generic;

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

        public Cliente GetByCpf(string cpf)
        {
            return Search(c => c.PessoaFisica.Cpf == cpf).FirstOrDefault();
        }

        public override IEnumerable<Cliente> GetAll()
        {
            return Db.Clientes.Where(c => c.Ativo).ToList();
        }

        public override void Remove(Guid id)
        {
            var cliente = GetById(id);
            cliente.Ativo = false;
            Update(cliente);
        }
    }
}
