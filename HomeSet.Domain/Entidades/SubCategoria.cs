using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSet.Domain.Entidades
{
    public class SubCategoria : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }      
        public virtual string Descripcion { get; set; }
        public virtual Categoria Categoria { get; set; }


    }
}
