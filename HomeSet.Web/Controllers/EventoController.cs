using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeSet.Models;
using HomeSet.Negocio;
using HomeSet.Domain.Dto;

namespace HomeSet.Controllers
{
    public class EventoController : Controller
    {
        private readonly INegocio Negocio;

        public EventoController(INegocio negocio)
        {
            Negocio = negocio;
        }

        public IActionResult Index()
        {
            var dto = new EventoDto();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Alta(EventoDto dto)
        {
            Negocio.AltaEvento(dto);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
