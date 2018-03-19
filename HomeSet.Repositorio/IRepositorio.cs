using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace HomeSet.Repositorio
{
    public interface IRepositorio
    {
        int GuardarCambios();

        TEntity Obtener<TEntity>(object id) where TEntity : class;

        EntityEntry<TEntity> Agregar<TEntity>(TEntity entidad) where TEntity : class;

        EntityEntry<TEntity> Remover<TEntity>(object id) where TEntity : class;

        EntityEntry<TEntity> Remover<TEntity>(TEntity entidad) where TEntity : class;

        EntityEntry<TEntity> Actualizar<TEntity>(TEntity entidad) where TEntity : class;



    }
}
