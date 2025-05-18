using System.Net.Mail;
using System.Text.Json;
using System.Text;

namespace juego_impostor_backend.API.AlertMessage
{
    public class AlertMessageHandler(ILogger<AlertMessageHandler> logger, IConfiguration c) : IAlertMessageHandler
    {
        private readonly ILogger<AlertMessageHandler> _logger = logger;
        private readonly IConfiguration _c = c;

        public void SendAlertMessage(string mensaje)
        {
            // Enviar mensaje por webhook de Teams (es un chat preparado para alertas)
            SendWebhook(mensaje);
            // Enviar mensaje por mail
            SendMail(mensaje);
        }

        public void SendWebhook(string mensaje)
        {
            try
            {
                string webhookUrl = _c["WEBHOOK"];
                var body = new { text = $"<h1>{_c["TITLE"]}</h1><p>Aplicación: <b>{_c["APP_NAME"]}</b></p><p>Env: <b>{_c["ENV"]}</b></p><p>Hora: <b>{DateTime.Now:HH:mm}hs</b></p><hr><p>{mensaje}</p>" };
                string jsonBody = JsonSerializer.Serialize(body);

                using (HttpClient client = new())
                {
                    HttpContent content = new StringContent(jsonBody, Encoding.UTF8, "application/json");
                    HttpResponseMessage response = client.PostAsync(webhookUrl, content).GetAwaiter().GetResult();

                    if (response.IsSuccessStatusCode)
                        _logger.LogInformation("Mensaje enviado correctamente al webhook: " + mensaje);
                    else
                        _logger.LogError($"Error al enviar el mensaje al webhook. Código de estado: {response.StatusCode}");
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR: Hubo un problema al intentar enviar el mensaje por webhook: " + ex.Message);
            }
        }

        public void SendMail(string mensaje)
        {
            try
            {
                string[] mails = _c["MAIL_TO"].Split(",");

                MailMessage mailMessage = new()
                {
                    IsBodyHtml = true,
                    Priority = MailPriority.Normal,
                    Subject = $"Env: {_c["ENV"]}. {_c["TITLE"]}: ERROR EN SERVICIO {_c["APP_NAME"]}",
                    Body = mensaje,
                    From = new MailAddress(_c["MAIL_FROM"])
                };

                foreach (string mail in mails)
                    mailMessage.To.Add(mail);

                SmtpClient smtpClient = new(_c["MAIL_SERVER"]) { UseDefaultCredentials = false };

                smtpClient.Send(mailMessage);

                mailMessage.Dispose();

                _logger.LogInformation("Mensaje enviado correctamente al email: " + mensaje);
            }
            catch (Exception ex)
            {
                _logger.LogError("ERROR: Hubo un problema al intentar enviar el mensaje por mail: " + ex.Message);
            }
        }

    }
}