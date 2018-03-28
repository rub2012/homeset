using System.ComponentModel.DataAnnotations;

namespace HomeSet.Domain.Entidades
{
    public class Categoria : IIdentificable
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual string Descripcion { get; set; }

    }
}
