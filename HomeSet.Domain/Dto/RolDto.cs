using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace HomeSet.Domain.Dto
{
    public class RolDto
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "El Campo '{0}' es requerido")]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }
    }
}
