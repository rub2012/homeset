using System.ComponentModel.DataAnnotations;

namespace HomeSet.Domain.Entidades
{
    public class Categoria
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Descripcion { get; set; }

    }
}
