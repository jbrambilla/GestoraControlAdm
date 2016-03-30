using EGestora.GestoraControlAdm.Domain.Interfaces.MailService;
using System.IO;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Linq;
using System;
using System.Net;

namespace EGestora.GestoraControlAdm.Infra.Data.MailService
{
    public class EmailService : IEmailService
    {
        private MailMessage MailMessage;

        public EmailService()
        {
            MailMessage = new MailMessage();
        }

        public bool Enviar()
        {
            if (!MailMessage.To.Any()) {
                return false;
            }
            if (MailMessage.From == null) {
                return false;
            }
            if (String.IsNullOrEmpty(MailMessage.Subject)) {
                return false;
            }
            if (String.IsNullOrEmpty(MailMessage.Body)) {
                return false;
            }

            using (var smtp = new SmtpClient())
            {
                var credential = new NetworkCredential
                {
                    UserName = "joao.brambilla@egestora.com.br",  // replace with valid value
                    Password = "85182mais"  // replace with valid value
                };
                smtp.Credentials = credential;
                smtp.Host = "smtp.gmail.com";
                smtp.Port = 587;
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                try
                {
                    smtp.Send(MailMessage);
                    return true;
                }
                catch (SmtpFailedRecipientException ex)
                {
                    return false;
                }
            }
        }

        public void AdicionarAnexo(Stream anexo, string nome)
        {
            MailMessage.Attachments.Add(new Attachment(anexo, nome));
        }

        public void AdicionarAnexo(byte[] anexo, string nome)
        {
            Attachment attachment;
            using (var stream = new MemoryStream())
            {
                stream.Write(anexo, 0, anexo.Length - 1);
                attachment = new Attachment(stream, nome);
            }
            var message = new MailMessage();
            message.Attachments.Add(attachment);
        }


        public void AdicionarDestinatário(string destinatário)
        {
            MailMessage.To.Add(new MailAddress(destinatário));
        }

        public void AdicionarAssunto(string assunto)
        {
            MailMessage.Subject = assunto;
        }

        public void AdicionarCorpo(string texto)
        {
            MailMessage.Body = texto;
        }

        public void AdicionarRemetente(string remetente)
        {
            MailMessage.From = new MailAddress(remetente);
        }
    }
}
