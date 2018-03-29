using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeSet.Domain.Dto
{
    public class EventoDto
    {
        public int Id { get; set; }
        [Display]
        public string Descripcion { get; set; }
        public SubCategoriaDto SubCategoria { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }
    }
}
