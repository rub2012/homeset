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
        }
    }
}
