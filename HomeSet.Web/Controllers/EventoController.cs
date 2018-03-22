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
        [ActionName("Listar")]
        public ActionResult Listar(string filtro, int pagina = 1, string ordenarPor = "Id", DirOrden dirOrden = DirOrden.Asc)
        {
            //ListQuery(filtro, pagina, ordenarPor, dirOrden);
            var eventos = new List<EventoDto>{
                new EventoDto{ Descripcion = "Manada"},
                new EventoDto{ Descripcion = "Moto"},
                new EventoDto{ Descripcion = "lavada"},
                new EventoDto{ Descripcion = "secada"},
                new EventoDto{ Descripcion = "tomada"},
            };
            //return View("Index", new ListaPaginada<EventoDto>(eventos, 1, 10, 10));
            ViewBag.Items = new ListaPaginada<EventoDto>(eventos, 1, 10, 10);
            return View("Index", (object)filtro);
        }

        public IActionResult Index(string sortOrder, string searchString)
        {
            ViewData["NameSortParm"] = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            //var students = from s in _context.Students
            //               select s;
            //if (!String.IsNullOrEmpty(searchString))
            //{
            //    students = students.Where(s => s.LastName.Contains(searchString)
            //                           || s.FirstMidName.Contains(searchString));
            //}
            
            var eventos = new List<EventoDto>{
                new EventoDto{ Descripcion = "Manada"},
                new EventoDto{ Descripcion = "Moto"},
                new EventoDto{ Descripcion = "lavada"},
                new EventoDto{ Descripcion = "secada"},
                new EventoDto{ Descripcion = "tomada"},
            };

            switch (sortOrder)
            {
                case "name_desc":
                    eventos = eventos.OrderByDescending(s => s.Descripcion).ToList();
                    break;
                default:
                    eventos = eventos.OrderBy(s => s.Descripcion).ToList();
                    break;
            }
            ViewBag.Items = new ListaPaginada<EventoDto>(eventos, 1, 10, 10);
            return View(new ListaPaginada<EventoDto>(eventos, 1,10,10));
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

        private void ListQuery(string filtro, int pagina, string ordenarPor, DirOrden dirOrden)
        {
            var paginacion = new Paginacion(ordenarPor, dirOrden, pagina, 10);

            ViewBag.Items = Negocio.ListarEventosPaginado(filtro, paginacion);
        }
    }
}
