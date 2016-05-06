using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;
using System.Linq;
using System.Collections.Generic;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class EnderecoRepository : RepositoryBase<Endereco>, IEnderecoRepository
    {
        public EnderecoRepository(EGestoraContext context)
            : base(context)
        {

        }

        public IEnumerable<Endereco> GetAllByPessoaId(Guid id)
        {
            return Search(e => e.PessoaId == id).ToList();
        }
    }
}
