using DomainValidation.Interfaces.Specification;
using EGestora.GestoraControlAdm.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Domain.Specifications.Pessoas.PJ
{
    class PessoaCnaePrincipalNaoDeveEstarNaListaDeCnaesSpecification : ISpecification<Pessoa>
    {
        public bool IsSatisfiedBy(Pessoa pessoa)
        {
            if (pessoa.PessoaJuridica == null)
            {
                return true;
            }
            return !pessoa.PessoaJuridica.CnaeList.Where(c => c.CnaeId == pessoa.PessoaJuridica.CnaeId).Any();
        }
    }
}
