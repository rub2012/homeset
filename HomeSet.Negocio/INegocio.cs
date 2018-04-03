using HomeSet.Domain;
using HomeSet.Domain.Dto;
using System;
using System.Collections.Generic;

namespace HomeSet.Negocio
{
    public interface INegocio
    {
        TEntityDto Obtener<TEntity, TEntityDto>(int id) where TEntity : class, IIdentificable where TEntityDto : class;
        int Alta<TEntity, TEntityDto>(TEntityDto dto) where TEntity : class where TEntityDto : class;
        void Baja<TEntity>(int id) where TEntity : class, IIdentificable;
        void Modificacion<TEntity, TEntityDto>(TEntityDto dto) where TEntity : class where TEntityDto : class;
        IEnumerable<EventoDto> ListarEventos();
        ListaPaginada<EventoDto> ListarEventosPaginado(string filtro, Paginacion paginacion);
        IEnumerable<CategoriaDto> ListarCategorias();
        IEnumerable<SubCategoriaDto> ListarSubCategoriasPorCategoriaId(int categoriaId);
        Resultado AltaEvento(EventoDto dto);
        Resultado ModificarEvento(EventoDto dto);
        Resultado EliminarEvento(int id);
        ListaPaginada<SubCategoriaDto> ListarSubCategoriasPaginado(string filtro, Paginacion paginacion);
        Resultado AltaSubCategoria(SubCategoriaDto dto);
        Resultado ModificarSubCategoria(SubCategoriaDto dto);
        Resultado EliminarSubCategoria(int id);
        ListaPaginada<CategoriaDto> ListarCategoriasPaginado(string filtro, Paginacion paginacion);
        Resultado AltaCategoria(CategoriaDto dto);
        Resultado ModificarCategoria(CategoriaDto dto);
        Resultado EliminarCategoria(int id);
    }
}
