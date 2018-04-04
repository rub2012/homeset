using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HomeSet.Domain.Entidades
{
    public class Usuario : IdentityUser<int>
    {
        public virtual string Nombre { get; set; }
        public virtual string Apellido { get; set; }
    }
}
