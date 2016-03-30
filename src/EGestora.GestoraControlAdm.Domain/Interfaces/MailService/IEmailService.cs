using System.IO;
using System.Threading.Tasks;
namespace EGestora.GestoraControlAdm.Domain.Interfaces.MailService
{
    public interface IEmailService
    {
        bool Enviar();
        void AdicionarAnexo(Stream anexo, string nome);
        void AdicionarAnexo(byte[] anexo, string nome);
        void AdicionarDestinatário(string destinatário);
        void AdicionarRemetente(string remetente);
        void AdicionarAssunto(string assunto);
        void AdicionarCorpo(string texto);
    }
}
