using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSet.Domain.Entidades
{
    public class Evento : IIdentificable
    {

        [Key]
        public virtual int Id { get; set; }
        public virtual string Descripcion { get; set; }
        public virtual SubCategoria SubCategoria { get; set; }
        public virtual DateTime Fecha { get; set; }

    }
}
