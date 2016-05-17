using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Repository;
using EGestora.GestoraControlAdm.Infra.Data.Context;

namespace EGestora.GestoraControlAdm.Infra.Data.Repository
{
    public class CargoRepository : RepositoryBase<Cargo>, ICargoRepository
    {
        public CargoRepository(EGestoraContext context)
            :base (context)
        {

        }
    }
}
