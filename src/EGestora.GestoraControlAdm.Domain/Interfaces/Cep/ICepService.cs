using EGestora.GestoraControlAdm.Domain.Entities;

namespace EGestora.GestoraControlAdm.Domain.Interfaces.Cep
{
    public interface ICepService
    {
        Endereco GetAddressByCep(string cep);
    }
}
