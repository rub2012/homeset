using AutoMapper;
using HomeSet.Domain.Dto;
using HomeSet.Domain.Entidades;

namespace HomeSet.Domain
{
    public class Mapeo : Profile
    {
        public Mapeo()
        {
            CreateMap<Evento, EventoDto>()
                .ForMember(x => x.CategoriaDescripcion,x => x.MapFrom(s => s.SubCategoria.Categoria.Descripcion))
                .ForMember(x => x.SubCategoriaDescripcion, x => x.MapFrom(s => s.SubCategoria.Descripcion))
                .ForMember(x => x.CategoriaId, x => x.MapFrom(s => s.SubCategoria.Categoria.Id));
            CreateMap<EventoDto, Evento>();

            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();

            CreateMap<SubCategoria, SubCategoriaDto>()
                .ForMember(x => x.CategoriaDescripcion, x => x.MapFrom(s => s.Categoria.Descripcion));
            CreateMap<SubCategoriaDto, SubCategoria>();
        }
    }
}
