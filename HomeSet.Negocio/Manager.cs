using AutoMapper;
using HomeSet.Domain;
using HomeSet.Domain.Dto;
using HomeSet.Domain.Entidades;
using HomeSet.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

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
        public int Alta<TEntity,TEntityDto>(TEntityDto dto) where TEntity : class where TEntityDto : class
        {
            var entidad = Mapper.Map<TEntity>(dto);
            var resultado = Repositorio.Agregar(entidad);
            Repositorio.GuardarCambios();
            return 0;

        }

        public void Baja<TEntity>(int id) where TEntity : class
        {
            var resultado = Repositorio.Remover<TEntity>(id);
            Repositorio.GuardarCambios();
        }

        public void Modificacion<TEntity, TEntityDto>(TEntityDto dto) where TEntity : class where TEntityDto : class
        {
            var entidad = Mapper.Map<TEntityDto, TEntity>(dto);
            //var evento = Repositorio.Obtener<Evento>(dto.Id);
            var resultado = Repositorio.Actualizar(entidad);
            Repositorio.GuardarCambios();
        }

        public IList<EventoDto> ListarEventos()
        {
            var eventos = Repositorio.Listar<Evento>();
            return Mapper.Map<IEnumerable<EventoDto>>(eventos).ToList();
        }

        public ListaPaginada<EventoDto> ListarEventosPaginado(string filtro, Paginacion paginacion)
        {
            Expression<Func<Evento, bool>> expresionFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                filtro = filtro.Trim();
                expresionFiltro =
                    x =>
                    x.Descripcion.Contains(filtro);
                    //|| x.Nombre.Contains(filtro) ||
                    //x.TipoDocumentoIdentidad.DescripcionCorta.Contains(filtro) || x.NumeroDeDocumento.Contains(filtro);
            }

            var eventos = Repositorio.Listar<Evento>(expresionFiltro, paginacion);
            return Mapper.Map<ListaPaginada<EventoDto>>(eventos);

        }
    }
}
