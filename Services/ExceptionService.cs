using System.Net;
using JuegoImpostor.Models;

namespace JuegoImpostor.Services
{
    public class ExceptionService : Exception
    {
        ErrorModel ErrorModel { get; set; } = new();
        public ExceptionService(string message, HttpStatusCode statusCode) : base(message)
        {
            ErrorModel.Message = message;
            ErrorModel.StatusCode = statusCode;
        }

        public ExceptionService BadRequest(ErrorModel errorModel)
        {
            return new ExceptionService(errorModel.Message, HttpStatusCode.BadRequest);
        }

    }
}
