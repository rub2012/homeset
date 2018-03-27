using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSet.Domain.Entidades
{
    public class SubCategoria
    {
        [Key]
        //public virtual int SubCategoriaId { get; set; }
        public virtual int Id { get; set; }
        //public virtual int Id { get { return SubCategoriaId; } }        
        public virtual string Descripcion { get; set; }
        //public virtual int CategoriaId { get; set; }
        //[ForeignKey("CategoriaId")]
        public virtual Categoria Categoria { get; set; }


    }
}
