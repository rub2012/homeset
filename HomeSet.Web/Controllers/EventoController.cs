using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeSet.Models;
using HomeSet.Negocio;
using HomeSet.Domain.Dto;
using HomeSet.Domain.Entidades;
using HomeSet.Domain;
using HomeSet.Domain.Atributos;
using System.Collections.Generic;
using System.Linq;

namespace HomeSet.Controllers
{
    public class EventoController : Controller
    {
        private readonly INegocio Negocio;

        public EventoController(INegocio negocio)
        {
            Negocio = negocio;
        }

        //public IActionResult Index()
        //{
        //    var dto = new EventoDto();
        //    return View(dto);
        //}

        //[AjaxOnly]
        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        [ActionName("Listar")]
        public ActionResult Listar(string filtro, int pagina = 1, string ordenarPor = "Id", DirOrden dirOrden = DirOrden.Asc)
        {
            //return View("Index", new ListaPaginada<EventoDto>(eventos, 1, 10, 10));
            //ViewBag.Items = new ListaPaginada<EventoDto>(eventos, 1, 10, 10);
            return View("Listar", ListQuery(filtro, pagina, ordenarPor, dirOrden));
        }

        [HttpGet]
        public IActionResult Index(string sortOrder, string searchString)
        {
            //ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            //ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            //ViewData["CurrentFilter"] = searchString;

            
            //ViewBag.Items = new ListaPaginada<EventoDto>(eventos, 1, 10, 10);
            return View(ListQuery("", 1, "Id", DirOrden.Asc));
        }

        [HttpPost]
        public IActionResult Alta(EventoDto dto)
        {
            Negocio.Alta<Evento,EventoDto>(dto);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private ListaPaginada<EventoDto> ListQuery(string filtro, int pagina, string ordenarPor, DirOrden dirOrden)
        {
            var paginacion = new Paginacion(ordenarPor, dirOrden, pagina, 5);

            return Negocio.ListarEventosPaginado(filtro, paginacion);
        }
    }
}
