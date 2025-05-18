namespace juego_impostor_backend.API.AlertMessage
{
    public interface IAlertMessageHandler
    {
        void SendAlertMessage(string mensaje);
        //void SendWebhook(string mensaje);
        //void SendMail(string mensaje);
    }
}
