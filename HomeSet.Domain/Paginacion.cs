using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSet.Domain
{
    public class Paginacion
    {
        public string OrdenarPor { get; private set; }
        public DirOrden DireccionOrden { get; private set; }
        public int Pagina { get; private set; }
        public int ItemsPorPagina { get; private set; }

        public Paginacion(
            string ordenarPor = null,
            DirOrden direccionOrden = DirOrden.Asc,
            int pagina = 1,
            int itemsPorPagina = 0)
        {
            OrdenarPor = ordenarPor;
            DireccionOrden = direccionOrden;
            Pagina = pagina;
            ItemsPorPagina = itemsPorPagina;
        }
    }
}
