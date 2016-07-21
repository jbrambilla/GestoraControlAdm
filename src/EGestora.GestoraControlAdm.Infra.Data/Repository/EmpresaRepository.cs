using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class EmpresaRepository : RepositoryBase<Empresa>, IEmpresaRepository
    {
        public EmpresaRepository(EGestoraContext context)
            : base (context)
        {
        }

        public Empresa GetEmpresaAtiva()
        {
            return Db.Empresas.FirstOrDefault(e => e.Pessoa.Ativo);
        }
    }
}
