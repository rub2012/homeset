using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeSet.Domain.Dto
{
    public class EventoDto
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Descripción")]
        public string Descripcion { get; set; }
        [Display(Name = "Sub-Categoría")]
        public int SubCategoriaId { get; set; }
        [Display(Name = "Sub-Categoría")]
        public string SubCategoriaDescripcion { get; set; }
        [Display(Name = "Categoría")]
        public int CategoriaId { get; set; }
        [Display(Name = "Categoría")]
        public string CategoriaDescripcion { get; set; }
        //public SubCategoriaDto SubCategoria { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime Fecha { get; set; }
    }
}
