using juego_impostor_backend.API.Exceptions;
using juego_impostor_backend.API.Models;
using System.Net;

namespace juego_impostor_backend.API.Responses
{
    public class ResponseHandler
    {
        public Meta meta { get; set; }
        public object data { get; set; }
        public List<Error> errors { get; set; }

        public static ResponseHandler BuildResponse(HttpContext httpContext, object data, ExceptionHandler ex = null)
        {
            ResponseHandler response = new()
            {
                meta = new Meta
                {
                    operation = httpContext.Request.Path,
                    method = httpContext.Request.Method
                },
                data = data != null ? data : "",
                errors = new List<Error>()
            };

            if (ex != null)
            {
                response.errors.Add(
                    new Error
                    {
                        message = ex.Message != null ? ex.Message : "",
                        status_code = ex.StatusCode.ToString()
                    }
                );
                httpContext.Response.StatusCode = (int)ex.StatusCode;
            }
            else
                httpContext.Response.StatusCode = (int)HttpStatusCode.OK;

            return response;
        }
    }
}




