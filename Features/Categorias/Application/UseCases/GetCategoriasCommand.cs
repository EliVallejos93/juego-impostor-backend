using juego_impostor_backend.Features.Categorias.Application.Interfaces;
using juego_impostor_backend.Features.Categorias.Application.DTOs;
using FluentValidation;
using MediatR;

namespace juego_impostor_backend.Features.Categorias.Application.UseCases
{
    // aca usamos MediatR para implementar el patron CQRS.
    // Tenemos la query GetCategoriasQuery que es la query modelo.
    // Esta query implementa la interfaz IRequest de MediatR, lo que significa que es una query que se puede enviar a través del mediador.
    // no tiene validacion porque no tiene propiedades, solo se usa para indicar que queremos obtener las categorias.
    // Y luego tenemos el handler que se encarga de manejar la query y llamar a la logica de negocio.

    // Query para traer las categorias del juego
    public class GetCategoriasQuery : IRequest<GetCategoriasDTOResponse>
    {
    }

    // Handler for GetCategoriasQuery
    public class GetCategoriasQueryHandler(IGetCategoriasService getCategoriasService) : IRequestHandler<GetCategoriasQuery, GetCategoriasDTOResponse>
    {
        IGetCategoriasService _getCategoriasService = getCategoriasService;

        public async Task<GetCategoriasDTOResponse> Handle(GetCategoriasQuery request, CancellationToken cancellationToken)
        {
            // Llama al servicio para que la logica vaya a buscar todas las categorias.
            GetCategoriasDTOResponse getCategoriasDTOResponse = new();
            getCategoriasDTOResponse = _getCategoriasService.TraerTodas();

            return getCategoriasDTOResponse;
        }
    }
}
