using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;
using System;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class UsuarioRepository : RepositoryBase<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(EGestoraContext context)
            :base (context)
        {
        }

        public void DesativarLock(string id)
        {
            var usuario = GetById(Guid.Parse(id));
            usuario.LockoutEnabled = false;
            Update(usuario);
        }
    }
}
