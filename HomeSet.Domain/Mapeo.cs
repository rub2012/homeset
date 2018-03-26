using AutoMapper;
using HomeSet.Domain.Dto;
using HomeSet.Domain.Entidades;

namespace HomeSet.Domain
{
    public class Mapeo : Profile
    {
        public Mapeo()
        {
            CreateMap<Evento, EventoDto>();
            CreateMap<EventoDto, Evento>();

            CreateMap<Categoria, CategoriaDto>();
            CreateMap<CategoriaDto, Categoria>();

            CreateMap<SubCategoria, SubCategoriaDto>();
            CreateMap<SubCategoriaDto, SubCategoria>();
        }
    }
}
