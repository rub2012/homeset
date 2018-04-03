using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeSet.Domain.Dto
{
    public class CategoriaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo '{0}' es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
    }
}
