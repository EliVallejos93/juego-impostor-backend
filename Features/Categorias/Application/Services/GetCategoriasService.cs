using juego_impostor_backend.Features.Categorias.Application.DTOs;
using juego_impostor_backend.Features.Categorias.Application.Interfaces;
using juego_impostor_backend.Features.Categorias.Domain.Entities;
using juego_impostor_backend.Features.Categorias.Infrastructure;
using juego_impostor_backend.Shared.Persistence;

namespace juego_impostor_backend.Features.Categorias.Application.Services
{
    public class GetCategoriasService(IUnitOfWork unitOfWork) : IGetCategoriasService
    {
        private readonly IUnitOfWork _unitOfWork = unitOfWork;

        public GetCategoriasDTOResponse TraerTodas()
        {
            List<CategoriaEntity> categoriasTodas = _unitOfWork.Categorias.TraerTodas().Result;
            List<SubCategoriaEntity> subCategoriasTodas = _unitOfWork.SubCategorias.TraerTodas().Result;

            GetCategoriasDTOResponse getCategoriasDTOResponse = new();
            foreach (var categoria in categoriasTodas)
            {
                getCategoriasDTOResponse.Categorias.Add(new CategoriaDTO()
                {
                    Id = categoria.Id,
                    Categoria = categoria.Categoria,
                    SubCategorias = subCategoriasTodas.Where(x => x.IdCategoria == categoria.Id).ToList()
                });
            }

            return getCategoriasDTOResponse;
        }
    }
}
