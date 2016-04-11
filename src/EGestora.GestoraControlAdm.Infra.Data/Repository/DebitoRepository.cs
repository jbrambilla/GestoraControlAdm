using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Linq;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class DebitoRepository : RepositoryBase<Debito>, IDebitoRepository
    {
        public DebitoRepository(EGestoraContext context)
            :base (context)
        {

        }

        public IEnumerable<Debito> GetAllToGrid(int skip, int take)
        {
            return Db.Debitos.OrderBy(d => d.Vencimento).Skip(skip).Take(take).ToList();
        }


        public void Baixar(Guid id)
        {
            var debito = GetById(id);
            debito.PagoEm = DateTime.Now;
            Update(debito);
        }
    }
}
