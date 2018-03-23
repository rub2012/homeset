using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace HomeSet.Domain
{
    public class ListaPaginada<TEntity> : IEnumerable<TEntity>
    {
        public int Pagina { get; private set; }
        public int ItemsPorPagina { get; private set; }
        public int ItemsTotales { get; private set; }
        public IList<TEntity> Items { get; private set; }

        public int PaginasTotales { get {
                return (ItemsTotales + ItemsPorPagina - 1 ) / ItemsPorPagina;
            } }

        public ListaPaginada(IList<TEntity> items, int pagina, int itemsPorPagina, int itemsTotales)
        {
            Items = items;
            Pagina = pagina;
            ItemsPorPagina = itemsPorPagina;
            ItemsTotales = itemsPorPagina == 0 ? items.Count : itemsTotales;
        }

        public IEnumerator<TEntity> GetEnumerator()
        {
            return Items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
