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
        IList<EventoDto> ListarEventos();
        ListaPaginada<EventoDto> ListarEventosPaginado(string filtro, Paginacion paginacion);
    }
}
