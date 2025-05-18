using FluentValidation;
using juego_impostor_backend.API.Exceptions;
using juego_impostor_backend.API.Models;
using juego_impostor_backend.API.Responses;
using MediatR;
using System.Net;

namespace juego_impostor_backend.Shared.Behaviors
{
    public class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IHttpContextAccessor httpContextAccessor)
        {
            _validators = validators;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var failures = _validators
                .Select(v => v.Validate(context))
                .SelectMany(r => r.Errors)
                .Where(f => f != null)
                .ToList();

            if (failures.Count != 0)
            {
                var httpContext = _httpContextAccessor.HttpContext;

                var response = new ResponseHandler
                {
                    meta = new Meta
                    {
                        operation = httpContext?.Request?.Path,
                        method = httpContext?.Request?.Method
                    },
                    data = "",
                    errors = failures.Select(f => new Error
                    {
                        message = f.ErrorMessage,
                        detail = $"Propiedad: {f.PropertyName}",
                        status_code = HttpStatusCode.Conflict.ToString()
                    }).ToList()
                };

                // Lanzar excepción personalizada para que tu middleware de errores la capture
                ExceptionHandler.BadRequest("Error de validación", response.errors);
            }

            return await next();
        }
    }

}
