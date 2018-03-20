using HomeSet.Domain.Dto;
using System;

namespace HomeSet.Negocio
{
    public interface INegocio
    {
        int AltaEvento(EventoDto dto);
        void BajaEvento(EventoDto dto);
        void ModificacionEvento(EventoDto dto);
    }
}
