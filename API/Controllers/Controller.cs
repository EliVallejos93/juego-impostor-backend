using juego_impostor_backend.Features.ConfiguracionJuego.Application.UseCases;
using juego_impostor_backend.Features.Categorias.Application.UseCases;
using juego_impostor_backend.API.Responses;
using juego_impostor_backend.Features.ConfiguracionJuego.Application.DTOs;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace juego_impostor_backend.API.Controllers
{
    [ApiController]
    [Route("juego-impostor-backend")]
    public class Controller(ILogger<Controller> logger, IMediator mediator) : ControllerBase
    {
        private readonly ILogger<Controller> _logger = logger;
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [Route("get-categorias", Name = "GetCategorias")]
        [SwaggerOperation("Trae todas las categorias y subcategorias.")]
        public async Task<ResponseHandler> GetCategorias(GetCategoriasCommand command)
        {
            return ResponseHandler.BuildResponse(HttpContext, await _mediator.Send(command));
        }

        [HttpPost]
        [Route("set-configuracion", Name = "SetConfiguracion")]
        [SwaggerOperation ("Configura los parámetros iniciales del juego (cantidad de impostores, jugadores, palabra secreta, etc.).")]
        public async Task<ResponseHandler> SetConfiguracion(ConfiguracionCommand command)
        {
            return ResponseHandler.BuildResponse(HttpContext, await _mediator.Send(command));
        }
    }
}
