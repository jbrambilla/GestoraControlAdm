using System;
namespace EGestora.GestoraControlAdm.Domain.Entities
{
    public class RegimeApuracao
    {
        public RegimeApuracao()
        {
            RegimeApuracaoId = Guid.NewGuid();
        }

        public Guid RegimeApuracaoId { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
    }
}
