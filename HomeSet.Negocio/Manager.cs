using HomeSet.Domain.Dto;
using HomeSet.Domain.Entidades;
using HomeSet.Repositorio;

namespace HomeSet.Negocio
{
    public class Manager : INegocio
    {
        private readonly IRepositorio Repositorio;
        public Manager(IRepositorio repositorio)
        {
            Repositorio = repositorio;
        }
        public int AltaEvento(EventoDto dto)
        {
            var resultado = Repositorio.Agregar<Evento>(new Evento
            {
                Descripcion = dto.Descripcion
            });
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
    }
}
