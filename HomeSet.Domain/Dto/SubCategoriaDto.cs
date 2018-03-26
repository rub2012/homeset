using System;
using System.Collections.Generic;
using System.Text;

namespace HomeSet.Domain.Dto
{
    public class SubCategoriaDto
    {
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public CategoriaDto Categoria { get; set; }
        
    }
}
