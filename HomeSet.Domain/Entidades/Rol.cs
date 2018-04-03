using Microsoft.AspNetCore.Identity;

namespace HomeSet.Domain.Entidades
{
    public class Rol : IdentityRole
    {
        public override string Id { get; set; }
        //public override string Rol { get; set; }

    }
}
