using HomeSet.Domain;
using HomeSet.Domain.Entidades;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace HomeSet.Repositorio
{
    public interface IRepositorio
    {
        int GuardarCambios();

        TEntity Obtener<TEntity>(int id) where TEntity : class , IIdentificable;

        EntityEntry<TEntity> Agregar<TEntity>(TEntity entidad) where TEntity : class;

        EntityEntry<TEntity> Remover<TEntity>(int id) where TEntity : class, IIdentificable;

        EntityEntry<TEntity> Remover<TEntity>(TEntity entidad) where TEntity : class;

        EntityEntry<TEntity> Actualizar<TEntity>(TEntity entidad) where TEntity : class;

        IEnumerable<TEntity> Listar<TEntity>(Expression<Func<TEntity, bool>> condicion = null, int? maxResultados = null) where TEntity : class;

        ListaPaginada<TEntity> Listar<TEntity>(Expression<Func<TEntity, bool>> condicion, Paginacion paginacion) where TEntity : class;



    }
}
