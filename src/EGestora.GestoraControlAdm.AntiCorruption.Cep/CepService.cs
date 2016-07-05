using Canducci.Zip;
using EGestora.GestoraControlAdm.Domain.Entities;
using EGestora.GestoraControlAdm.Domain.Interfaces.Cep;

namespace EGestora.GestoraControlAdm.AntiCorruption.Cep
{
    public class CepService : ICepService
    {

        public Endereco GetAddressByCep(string cep)
        {
            var address = new Endereco();
            address.Erro = true;
            try
            {
                //Observação
                //Formato válido para o CEP: 01414000 ou 01414-000 ou 01.414-000

                ZipCodeLoad zipLoad = new ZipCodeLoad();

                ZipCode zipCode = null;
                if (ZipCode.TryParse(cep, out zipCode))
                {
                    ZipCodeInfo zipCodeInfo = zipLoad.Find(zipCode);

                    if (!zipCodeInfo.Erro)
                    {
                        address.Bairro = zipCodeInfo.District;
                        address.Cep = cep;
                        address.Cidade = zipCodeInfo.City;
                        address.Complemento = zipCodeInfo.Complement;
                        address.Estado = zipCodeInfo.Uf;
                        address.Ibge = zipCodeInfo.Ibge;
                        address.Logradouro = zipCodeInfo.Address;
                        address.Erro = false;
                    }
                }

            }
            catch (ZipCodeException ex)
            {
                throw ex;
            }

            return address;
        }
    }
}
