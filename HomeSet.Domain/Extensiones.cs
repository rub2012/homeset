using HomeSet.Domain.Entidades;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.CompilerServices;
using System.Text;

namespace HomeSet.Domain
{
    public static class Extensiones
    {
        public static IQueryable<TSource> OrderBy<TSource>(this IQueryable<TSource> query, string key, bool ascending = true)
        {
            if (string.IsNullOrWhiteSpace(key))
            {
                return query;
            }

            var lambda = (dynamic)CreateExpression(typeof(TSource), key);

            return ascending
                ? Queryable.OrderBy(query, lambda)
                : Queryable.OrderByDescending(query, lambda);
        }

        private static LambdaExpression CreateExpression(Type type, string propertyName)
        {
            var param = Expression.Parameter(type, "x");

            Expression body = param;
            foreach (var member in propertyName.Split('.'))
            {
                body = Expression.PropertyOrField(body, member);
            }

            return Expression.Lambda(body, param);
        }

        public static TRelated Load<TRelated>(
            this Action<object, string> loader,
            object entity,
            ref TRelated navigationField,
            [CallerMemberName] string navigationName = null)
            where TRelated : class
        {
            loader?.Invoke(entity, navigationName);

            return navigationField;
        }

        public static IQueryable<TEntity> LoadRelated<TEntity>(this IQueryable<TEntity> source,bool cargar = true) where TEntity : class
        {
            if (cargar)
            {
                var tipo = typeof(TEntity);
                if (tipo == typeof(Evento))
                {
                    var source2 = source as IQueryable<Evento>;
                    source2 = source2.Include(s => s.SubCategoria).ThenInclude(s => s.Categoria);
                    return source2 as IQueryable<TEntity>;
                }
                else if (tipo == typeof(SubCategoria))
                {
                    var source2 = source as IQueryable<SubCategoria>;
                    source2 = source2.Include(s => s.Categoria);
                    return source2 as IQueryable<TEntity>;
                }
                else
                {
                    return source;
                }
                //else if (tipo == typeof(Categoria))
                //{
                //    var source2 = source as IQueryable<Categoria>;
                //    source2.Include(s => s.).ThenInclude(s => s.Categoria);
                //    return source2 as IQueryable<TEntity>;
                //}
            }
            else
            {
                return source;
            }

        }

    }
}
