using System;
using System.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ThomasSalon.UI.Controllers
{
    public class BoletinController : Controller
    {
        [HttpPost]
        public async Task<ActionResult> Suscribirse(string correo)
        {
            if (string.IsNullOrEmpty(correo))
                return Json(new { success = false, message = "El correo es inválido" });

            string asunto = "¡Bienvenido a Thomas Salon!";
            string mensaje = "<h2>Gracias por suscribirte</h2><p>Te mantendremos informado sobre nuestras promociones y servicios.</p>";

            bool enviado = await EnviarCorreo(correo, asunto, mensaje);

            if (enviado)
                return Json(new { success = true, message = "Te has suscrito con éxito. Revisa tu correo." });
            else
                return Json(new { success = false, message = "Hubo un problema al enviar el correo." });
        }

        private async Task<bool> EnviarCorreo(string destinatario, string asunto, string mensaje)
        {
            try
            {
                var smtpClient = new SmtpClient(ConfigurationManager.AppSettings["SmtpServer"])
                {
                    Port = int.Parse(ConfigurationManager.AppSettings["Port"]),
                    Credentials = new NetworkCredential(
                        ConfigurationManager.AppSettings["SenderEmail"],
                        ConfigurationManager.AppSettings["SenderPassword"]
                    ),
                    EnableSsl = true
                };

                var mailMessage = new MailMessage
                {
                    From = new MailAddress(ConfigurationManager.AppSettings["SenderEmail"]),
                    Subject = asunto,
                    Body = mensaje,
                    IsBodyHtml = true
                };
                mailMessage.To.Add(destinatario);

                await smtpClient.SendMailAsync(mailMessage);
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
