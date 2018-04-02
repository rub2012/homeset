using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeSet.Domain.Dto
{
    public class SubCategoriaDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo '{0}' es requerido")]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Required(ErrorMessage = "El Campo '{0}' es requerido")]
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }
        [Display(Name = "Categoría")]
        public string CategoriaDescripcion { get; set; }

    }
}
