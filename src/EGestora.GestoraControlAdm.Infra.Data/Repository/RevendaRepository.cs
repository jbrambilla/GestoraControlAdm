using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class RevendaRepository : RepositoryBase<Revenda>, IRevendaRepository
    {
        public RevendaRepository(EGestoraContext context)
            : base(context)
        {

        }

        public Revenda GetByCnpj(string cnpj)
        {
            return Search(f => f.PessoaJuridica.Cnpj == cnpj).FirstOrDefault();
        }

        public Revenda GetByCpf(string cpf)
        {
            return Search(f => f.PessoaFisica.Cpf == cpf).FirstOrDefault();
        }

        public override IEnumerable<Revenda> GetAll()
        {
            return Db.Revendas.Where(c => c.Ativo).ToList();
        }

        public override void Remove(Guid id)
        {
            var revenda = GetById(id);
            revenda.Ativo = false;
            Update(revenda);
        }
    }
}
