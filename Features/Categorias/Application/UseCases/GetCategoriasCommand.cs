using juego_impostor_backend.Features.Categorias.Application.Interfaces;
using juego_impostor_backend.Features.Categorias.Application.DTOs;
using FluentValidation;
using MediatR;

namespace juego_impostor_backend.Features.Categorias.Application.UseCases
{
    // aca usamos MediatR para implementar el patron CQRS.
    // Tenemos el comando GetCategoriasCommand que es el comando modelo.
    // Este comando implementa la interfaz IRequest de MediatR, lo que significa que es un comando que se puede enviar a través del mediador.
    // A su vez usamos FluentValidation para validar el comando antes de que se ejecute.
    // Y luego tenemos el handler que se encarga de manejar el comando y crear el usuario en la base de datos.

    // Command para traer las categorias del juego
    public class GetCategoriasCommand : IRequest<GetCategoriasDTOResponse>
    {
    }

    // Handler for GetCategoriasCommand
    public class GetCategoriasCommandHandler(IGetCategoriasService getCategoriasService) : IRequestHandler<GetCategoriasCommand, GetCategoriasDTOResponse>
    {
        IGetCategoriasService _getCategoriasService = getCategoriasService;

        public async Task<GetCategoriasDTOResponse> Handle(GetCategoriasCommand request, CancellationToken cancellationToken)
        {
            // Llama al servicio para que la logica vaya a buscar todas las categorias.
            GetCategoriasDTOResponse getCategoriasDTOResponse = new();
            getCategoriasDTOResponse = _getCategoriasService.TraerTodas();

            return getCategoriasDTOResponse;
        }
    }
}
