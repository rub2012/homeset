using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace HomeSet.Domain.Entidades
{
    public class Usuario : IdentityUser
    {
        public override string Id { get; set; }
        public override string UserName { get; set; }

    }
}
