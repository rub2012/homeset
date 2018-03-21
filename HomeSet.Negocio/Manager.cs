using AutoMapper;
using HomeSet.Domain.Dto;
using HomeSet.Domain.Entidades;
using HomeSet.Repositorio;
using System.Collections.Generic;
using System.Linq;

namespace HomeSet.Negocio
{
    public class Manager : INegocio
    {
        private readonly IRepositorio Repositorio;
        private readonly IMapper Mapper;
        public Manager(IRepositorio repositorio, IMapper mapper)
        {
            Repositorio = repositorio;
            Mapper = mapper;
        }
        public int AltaEvento(EventoDto dto)
        {
            var entidad = Mapper.Map<Evento>(dto);
            var resultado = Repositorio.Agregar(entidad);
            Repositorio.GuardarCambios();
            return 0;

        }

        public void BajaEvento(EventoDto dto)
        {
            var resultado = Repositorio.Remover<Evento>(dto.Id);
            Repositorio.GuardarCambios();
        }

        public void ModificacionEvento(EventoDto dto)
        {
            var entidad = Mapper.Map<EventoDto, Evento>(dto);
            //var evento = Repositorio.Obtener<Evento>(dto.Id);
            var resultado = Repositorio.Actualizar(entidad);
            Repositorio.GuardarCambios();
        }

        public IList<EventoDto> ListarEventos()
        {
            var eventos = Repositorio.Listar<Evento>();
            return Mapper.Map<IEnumerable<EventoDto>>(eventos).ToList();
        }
    }
}
