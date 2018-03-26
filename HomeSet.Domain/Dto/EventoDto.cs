﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSet.Domain.Dto
{
    public class EventoDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public SubCategoriaDto SubCategoria { get; set; }
        public DateTime Fecha { get; set; }
    }
}
