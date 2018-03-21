using HomeSet.Domain;
using HomeSet.Domain.Dto;
using System;
using System.Collections.Generic;

namespace HomeSet.Negocio
{
    public interface INegocio
    {
        int Alta<TEntity, TEntityDto>(TEntityDto dto) where TEntity : class where TEntityDto : class;
        void Baja<TEntity>(int id) where TEntity : class ;
        void Modificacion<TEntity, TEntityDto>(TEntityDto dto) where TEntity : class where TEntityDto : class;
        IList<EventoDto> ListarEventos();
    }
}
