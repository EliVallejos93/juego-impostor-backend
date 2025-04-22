using System.Net;

namespace JuegoImpostor.Models
{
    public class ResponseModel
    {
        public int StatusCode { get; set; } = 200;
        public string Message { get; set; } = string.Empty;
        public object? Data { get; set; } = null;
        public ErrorModel Error { get; set; } = new();
    }
    public class ErrorModel
    {
        public string Message { get; set; } = string.Empty;
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.BadRequest;
    }
}
