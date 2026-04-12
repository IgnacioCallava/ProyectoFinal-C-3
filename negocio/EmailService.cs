using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Mail;


namespace negocio
{
    public class EmailService
    {
        private MailMessage email;
        private SmtpClient server;

        public EmailService()
        {
            //Estas configuraciones las tenemos que sacar de mailtrap
            server = new SmtpClient();
            server.Credentials = new NetworkCredential("5a4db499583058", "****28f2");
            server.EnableSsl = true;
            server.Port = 2525;
            server.Host = "sandbox.smtp.mailtrap.io";

        }

        public void armarCorreo(string emailDestino, string asunto, string cuerpo)
        {
            //Armamos el correo, el mail que supuestamente lo envía, el asunto y el cuerpo.
            email = new MailMessage();
            email.From = new MailAddress("noresponder@articulos.co");
            email.To.Add(emailDestino);
            email.Subject = asunto;
            email.IsBodyHtml = true;
            email.Body = cuerpo;
        }

        public void enviarEmail()
        {
            //Esto solo envía el email.
            try
            {
                server.Send(email);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
