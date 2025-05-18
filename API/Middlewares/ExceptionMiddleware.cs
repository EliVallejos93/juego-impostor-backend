using juego_impostor_backend.API.Exceptions;
using juego_impostor_backend.API.Models;
using juego_impostor_backend.API.Responses;
using Newtonsoft.Json;
using System.Net;
using System.Text;

namespace juego_impostor_backend.API.Middlewares
{
    public class ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
    {
        private readonly RequestDelegate _next = next;
        private readonly ILogger<ExceptionMiddleware> _logger = logger;

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // Capturo la Excepcion y la manejo
                _logger.LogWarning("¿Response ya fue enviado?: " + context.Response.HasStarted);

                //_alertMessageHandler.SendAlertMessage(ex.Message);
                //_logger.LogError("Algo ha fallado " + JsonConvert.SerializeObject(ex));
                //return ResponseHandler.BuildResponse(HttpContext, null, ex);

                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            ResponseHandler response = new()
            {
                meta = new Meta
                {
                    operation = context.Request.Path,
                    method = context.Request.Method
                },
                data = "",
                errors = new List<Error>()
            };

            context.Response.Clear(); // <---- IMPORTANTE

            if (exception is ExceptionHandler exHandler)
            {
                context.Response.StatusCode = (int)exHandler.StatusCode;
                response.errors = exHandler.Errors ?? new List<Error>
        {
            new Error
            {
                message = exHandler.Message,
                status_code = exHandler.StatusCode.ToString()
            }
        };
            }
            else
            {
                context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                response.errors.Add(new Error
                {
                    message = "Ocurrió un error inesperado.",
                    detail = exception.Message,
                    status_code = "InternalServerError"
                });
            }

            context.Response.ContentType = "application/json";

            string result = JsonConvert.SerializeObject(response);
            context.Response.ContentLength = Encoding.UTF8.GetByteCount(result);

            _logger.LogWarning("Escribiendo respuesta de error: " + result);

            return context.Response.WriteAsync(result);
        }

    }

}
