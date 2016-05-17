using EGestora.GestoraControlAdm.Domain.Entities;
using System.Data.Entity.ModelConfiguration;

namespace EGestora.GestoraControlAdm.Infra.Data.EntityConfiguration
{
    public class CargoConfiguration : EntityTypeConfiguration<Cargo>
    {
        public CargoConfiguration()
        {
            HasKey(c => c.CargoId);
        }
    }
}
