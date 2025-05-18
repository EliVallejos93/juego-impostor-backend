using juego_impostor_backend.Features.ConfiguracionJuego.Application.Interfaces;
using juego_impostor_backend.Features.ConfiguracionJuego.Application.DTOs;
using FluentValidation;
using MediatR;

namespace juego_impostor_backend.Features.ConfiguracionJuego.Application.UseCases
{
    // aca usamos MediatR para implementar el patron CQRS.
    // Tenemos el comando ConfiguracionCommand que es el comando modelo.
    // Este comando implementa la interfaz IRequest de MediatR, lo que significa que es un comando que se puede enviar a través del mediador.
    // A su vez usamos FluentValidation para validar el comando antes de que se ejecute.
    // Y luego tenemos el handler que se encarga de manejar el comando y crear el usuario en la base de datos.

    // Command para configurar el juego
    public class ConfiguracionCommand : IRequest<ConfiguracionDTOResponse>
    {
        public configuracion configuracion { get; set; } = new();
    }

    // Validator for ConfiguracionCommand
    public class ConfiguracionCommandValidator : AbstractValidator<ConfiguracionCommand>
    {
        public ConfiguracionCommandValidator()
        {
            RuleFor(x => x.configuracion.CantImpostores)
                .InclusiveBetween(1, 10)
                .WithMessage("La cantidad de impostores debe ser de 1 a 10.");

            RuleFor(x => x.configuracion.Jugadores.Count())
                    .InclusiveBetween(3, 20)
                    .WithMessage("La cantidad de jugadores debe ser de 3 a 20.");

            RuleFor(x => x.configuracion)
                    .Must(x => x.Jugadores.Count() >= x.CantImpostores * 2)
                    .WithMessage("Debe haber al menos el doble de jugadores que impostores.");
            RuleFor(x => x.configuracion.Jugadores)
                .NotEmpty()
                .WithMessage("La lista de jugadores no puede estar vacía.")
                .Must(x => x.All(j => !string.IsNullOrWhiteSpace(j)))
                .WithMessage("No puede haber jugadores vacíos o con solo espacios.")
                .Must(x => x.Length == x.Distinct().Count())
                .WithMessage("No se pueden repetir jugadores.");
        }
    }

    // Handler for ConfiguracionCommand
    public class ConfiguracionCommandHandler(IConfiguracionService configuracionService) : IRequestHandler<ConfiguracionCommand, ConfiguracionDTOResponse>
    {
        IConfiguracionService _configuracionService = configuracionService;

        public async Task<ConfiguracionDTOResponse> Handle(ConfiguracionCommand request, CancellationToken cancellationToken)
        {
            // Llama al dominio para que la logica elija el o los impostores y la frase de verificacion.
            ConfiguracionDTOResponse configuracionDTOResponse = new();
            configuracionDTOResponse.ImpostoresSeleccionados = _configuracionService.ElegirImpostores(request.configuracion);
            configuracionDTOResponse.PalabraSecreta = _configuracionService.ElegirPalabraSecreta(request.configuracion);
            //configuracionDTOResponse.PalabrasSecretasTodas = _configuracionService.TraerTodasPalabrasSecretas();

            return configuracionDTOResponse;
        }
    }
}
