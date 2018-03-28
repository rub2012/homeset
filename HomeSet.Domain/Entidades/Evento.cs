using Microsoft.EntityFrameworkCore;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HomeSet.Domain.Entidades
{
    public class Evento : IIdentificable
    {
        //private ILazyLoader LazyLoader { get; set; }
        //private Action<object, string> LazyLoader { get; set; }
        //private SubCategoria _SubCategoria;

        //public Evento()
        //{
        //}

        //private Evento(Action<object, string> lazyLoader)
        //{
        //    LazyLoader = lazyLoader;
        //}

        //public SubCategoria SubCategoria
        //{
        //    get => LazyLoader?.Load(this, ref _SubCategoria);
        //    set => _SubCategoria = value;
        //}

        [Key]
        public virtual int Id { get; set; }
        //public virtual int SubCategoriaId { get; set; }
        public virtual string Descripcion { get; set; }
        //[ForeignKey("SubCategoriaId")]
        public virtual SubCategoria SubCategoria { get; set; }
        public virtual DateTime Fecha { get; set; }

    }
}
