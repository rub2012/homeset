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

        public TEntityDto Obtener<TEntity,TEntityDto>(int id) where TEntity : class, IIdentificable where TEntityDto : class
        {
            var entidad = Repositorio.Obtener<TEntity>(id);
            return Mapper.Map<TEntityDto>(entidad);

        }

        public int Alta<TEntity,TEntityDto>(TEntityDto dto) where TEntity : class where TEntityDto : class
        {
            var entidad = Mapper.Map<TEntity>(dto);
            var resultado = Repositorio.Agregar(entidad);
            return Repositorio.GuardarCambios();

        }

        public void Baja<TEntity>(int id) where TEntity : class ,IIdentificable
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

        public IEnumerable<EventoDto> ListarEventos()
        {
            var eventos = Repositorio.Listar<Evento>();
            return Mapper.Map<IEnumerable<EventoDto>>(eventos);
        }

        public ListaPaginada<EventoDto> ListarEventosPaginado(string filtro, Paginacion paginacion)
        {
            Expression<Func<Evento, bool>> expresionFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                filtro = filtro.Trim();
                expresionFiltro =
                    x =>
                    x.Descripcion.Contains(filtro)
                    || x.SubCategoria.Descripcion.Contains(filtro) 
                    || x.SubCategoria.Categoria.Descripcion.Contains(filtro);
            }

            var eventos = Repositorio.Listar<Evento>(expresionFiltro, paginacion);
            return MapearPaginado<Evento, EventoDto>(eventos);

        }

        public IEnumerable<CategoriaDto> ListarCategorias()
        {
            var categorias = Repositorio.Listar<Categoria>();
            return Mapper.Map<IEnumerable<CategoriaDto>>(categorias);
        }

        public IEnumerable<SubCategoriaDto> ListarSubCategoriasPorCategoriaId(int categoriaId)
        {
            var subCategorias = Repositorio.Listar<SubCategoria>(x => x.Categoria.Id == categoriaId,(int?) null, false);
            return Mapper.Map<IEnumerable<SubCategoriaDto>>(subCategorias);
        }

        private ListaPaginada<TEntityDto> MapearPaginado<TEntity,TEntityDto>(ListaPaginada<TEntity> entidadesPaginadas) where TEntity : class where TEntityDto : class
        {
            var itemsDto = Mapper.Map<IList<TEntityDto>>(entidadesPaginadas.Items);
            return new ListaPaginada<TEntityDto>(itemsDto, entidadesPaginadas.Pagina, entidadesPaginadas.ItemsPorPagina, entidadesPaginadas.ItemsTotales);
        }

        public Resultado AltaEvento(EventoDto dto)
        {
            var resultado = new Resultado();
            try
            {
                var evento = Mapper.Map<Evento>(dto);
                evento.SubCategoria = Repositorio.Obtener<SubCategoria>(dto.SubCategoriaId);
                Repositorio.Agregar(evento);
                Repositorio.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.Error("",e.Message);
            }
            return resultado;
        }

        public Resultado ModificarEvento(EventoDto dto)
        {
            var resultado = new Resultado();
            try
            {
                var evento = Mapper.Map<Evento>(dto);
                evento.SubCategoria = Repositorio.Obtener<SubCategoria>(dto.SubCategoriaId);
                Repositorio.Actualizar(evento);
                Repositorio.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.Error("", e.Message);
            }
            return resultado;
        }

        public Resultado EliminarEvento(int id)
        {
            var resultado = new Resultado();
            try
            {
                Repositorio.Remover<Evento>(id);
                Repositorio.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.Error("", e.Message);
            }
            return resultado;
        }

        public Resultado AltaSubCategoria(SubCategoriaDto dto)
        {
            var resultado = new Resultado();
            try
            {
                var subCategoria = Mapper.Map<SubCategoria>(dto);
                subCategoria.Categoria = Repositorio.Obtener<Categoria>(dto.CategoriaId);
                Repositorio.Agregar(subCategoria);
                Repositorio.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.Error("", e.Message);
            }
            return resultado;
        }

        public Resultado ModificarSubCategoria(SubCategoriaDto dto)
        {
            var resultado = new Resultado();
            try
            {
                var subCategorias = Mapper.Map<SubCategoria>(dto);
                subCategorias.Categoria = Repositorio.Obtener<Categoria>(dto.CategoriaId);
                Repositorio.Actualizar(subCategorias);
                Repositorio.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.Error("", e.Message);
            }
            return resultado;
        }

        public Resultado EliminarSubCategoria(int id)
        {
            var resultado = new Resultado();
            try
            {
                Repositorio.Remover<SubCategoria>(id);
                Repositorio.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.Error("", e.Message);
            }
            return resultado;
        }

        
            public ListaPaginada<SubCategoriaDto> ListarSubCategoriasPaginado(string filtro, Paginacion paginacion)
        {
            Expression<Func<SubCategoria, bool>> expresionFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                filtro = filtro.Trim();
                expresionFiltro =
                    x =>
                    x.Descripcion.Contains(filtro)
                    || x.Categoria.Descripcion.Contains(filtro);
            }

            var subCategorias = Repositorio.Listar<SubCategoria>(expresionFiltro, paginacion);
            return MapearPaginado<SubCategoria, SubCategoriaDto>(subCategorias);

        }

        public Resultado AltaCategoria(CategoriaDto dto)
        {
            var resultado = new Resultado();
            try
            {
                var Categoria = Mapper.Map<Categoria>(dto);
                Repositorio.Agregar(Categoria);
                Repositorio.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.Error("", e.Message);
            }
            return resultado;
        }

        public Resultado ModificarCategoria(CategoriaDto dto)
        {
            var resultado = new Resultado();
            try
            {
                var categoria = Mapper.Map<Categoria>(dto);
                Repositorio.Actualizar(categoria);
                Repositorio.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.Error("", e.Message);
            }
            return resultado;
        }

        public Resultado EliminarCategoria(int id)
        {
            var resultado = new Resultado();
            try
            {
                Repositorio.Remover<Categoria>(id);
                Repositorio.GuardarCambios();
            }
            catch (Exception e)
            {
                resultado.Error("", e.Message);
            }
            return resultado;
        }


        public ListaPaginada<CategoriaDto> ListarCategoriasPaginado(string filtro, Paginacion paginacion)
        {
            Expression<Func<Categoria, bool>> expresionFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                filtro = filtro.Trim();
                expresionFiltro =
                    x =>
                    x.Descripcion.Contains(filtro);
            }

            var Categorias = Repositorio.Listar<Categoria>(expresionFiltro, paginacion);
            return MapearPaginado<Categoria, CategoriaDto>(Categorias);

        }
    }
}
