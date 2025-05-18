using juego_impostor_backend.API.Models;
using System.Net;

namespace juego_impostor_backend.API.Exceptions
{
    public class ExceptionHandler : Exception
    {
        public ExceptionHandler(string message, List<Error>? errors = null) : base(message) { }

        public HttpStatusCode StatusCode { get; set; }
        public List<Error>? Errors { get; set; }

        public static ExceptionHandler Conflict(string message, List<Error>? errors = null) => Throw(HttpStatusCode.Conflict, message, errors);

        public static ExceptionHandler NoContent(string message, List<Error>? errors = null) => Throw(HttpStatusCode.NoContent, message, errors);

        public static ExceptionHandler BadRequest(string message, List<Error>? errors = null) => Throw(HttpStatusCode.BadRequest, message, errors);

        public static ExceptionHandler InternalServerError(string message, List<Error>? errors = null) => Throw(HttpStatusCode.InternalServerError, message, errors);

        public static ExceptionHandler Throw(HttpStatusCode statusCode, string message, List<Error>? errors = null)
        {
            throw new ExceptionHandler(message)
            {
                StatusCode = statusCode,
                Errors = errors,
            };
        }

    }
}
