using juego_impostor_backend.Features.IniciarPartida.Application.UseCases;
using juego_impostor_backend.Features.Categorias.Application.UseCases;
using juego_impostor_backend.API.Responses;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace juego_impostor_backend.API.Controllers
{
    [ApiController]
    [Route("api/juego-impostor-backend")]
    public class Controller(ILogger<Controller> logger, IMediator mediator) : ControllerBase
    {
        private readonly ILogger<Controller> _logger = logger;
        private readonly IMediator _mediator = mediator;

        [HttpGet]
        [Route("get-categorias", Name = "GetCategorias")]
        [SwaggerOperation("Trae todas las categorias y subcategorias.")]
        public async Task<ResponseHandler> GetCategorias([FromQuery] GetCategoriasQuery query)
        {
            return ResponseHandler.BuildResponse(HttpContext, await _mediator.Send(query));
        }

        [HttpPost]
        [Route("iniciar-partida", Name = "IniciarPartida")]
        [SwaggerOperation("Configura los parámetros iniciales del juego (cantidad de impostores, jugadores, palabra secreta, etc.) para iniciar la partida.")]
        public async Task<ResponseHandler> IniciarPartida([FromBody] IniciarPartidaCommand command)
        {
            return ResponseHandler.BuildResponse(HttpContext, await _mediator.Send(command));
        }
    }
}
