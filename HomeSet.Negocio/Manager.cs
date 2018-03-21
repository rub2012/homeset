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
            var entidad = Mapper.Map<EventoDto,Evento>(dto);
            var resultado = Repositorio.Agregar(entidad);
            Repositorio.GuardarCambios();
            return 0;

        }

        public void BajaEvento(EventoDto dto)
        {
            var resultado = Repositorio.Remover<Evento>(new Evento
            {
                Id = dto.Id,
                Descripcion = dto.Descripcion
            });
            Repositorio.GuardarCambios();
        }

        public void ModificacionEvento(EventoDto dto)
        {
            var evento = Repositorio.Obtener<Evento>(dto.Id);
            var resultado = Repositorio.Actualizar<Evento>(evento);
            Repositorio.GuardarCambios();
        }

        public IList<EventoDto> ListarEventos()
        {
            var s= Repositorio.Listar<Evento>().ToList();
            return null;
        }
    }
}
