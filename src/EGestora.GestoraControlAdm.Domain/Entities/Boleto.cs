using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class Boleto
    {
        public Boleto()
        {
            BoletoId = Guid.NewGuid();
        }

        public Guid BoletoId { get; set; }
        public Guid DebitoId { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime AlteradoEm { get; set; }

        public virtual Debito Debito { get; set; }
    }
}
