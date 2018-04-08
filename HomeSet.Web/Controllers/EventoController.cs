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
using System;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using Microsoft.AspNetCore.Authorization;

namespace HomeSet.Controllers
{
    [Authorize]
    public class EventoController : Controller
    {
        private readonly INegocio Negocio;

        public EventoController(INegocio negocio)
        {
            Negocio = negocio;
        }

        //[ValidateAntiForgeryToken]
        [AjaxOnly]
        [ActionName("Listar")]
        public ActionResult Listar(string filtro, int pagina = 1, string ordenarPor = "Id", DirOrden dirOrden = DirOrden.Asc)
        {
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
        [ValidateAntiForgeryToken]
        public IActionResult Crear(EventoDto dto)
        {
            if (ModelState.IsValid)
            {
                var resultado = Negocio.AltaEvento(dto);
                if (!resultado.HayErrores)
                {
                    return new AjaxEditSuccessResult();
                }
                ModelState.AgregarErrores(resultado);
            }
            CargarCategorias();
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Modificar(EventoDto dto)
        {
            if (ModelState.IsValid)
            {
                var resultado = Negocio.ModificarEvento(dto);
                if (!resultado.HayErrores)
                {
                    return new AjaxEditSuccessResult();
                }
                ModelState.AgregarErrores(resultado);
            }
            CargarCategorias();
            CargarSubCategorias(dto.CategoriaId);
            return View(dto);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            var dto = new EventoDto { Fecha = DateTime.Now };
            CargarCategorias();
            return View(dto);
        }

        [HttpGet]
        public IActionResult Modificar(int id)
        {
            var dto = Negocio.Obtener<Evento, EventoDto>(id);
            CargarCategorias();
            CargarSubCategorias(dto.CategoriaId);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Eliminar(int id)
        {
            var resultado = Negocio.EliminarEvento(id);
            return Content(!resultado.HayErrores ? "true" : resultado.Errores.Values.First());            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private ListaPaginada<EventoDto> ListQuery(string filtro, int pagina, string ordenarPor, DirOrden dirOrden)
        {
            var paginacion = new Paginacion(ordenarPor, dirOrden, pagina, 10);

            return Negocio.ListarEventosPaginado(filtro, paginacion);
        }

        private void CargarCategorias()
        {
            ViewBag.Categorias = Negocio.ListarCategorias().Select(item => new SelectListItem { Value = item.Id.ToString(CultureInfo.InvariantCulture), Text = item.Descripcion }).ToList();
        }

        private void CargarSubCategorias(int categoriaId)
        {
            ViewBag.SubCategorias = Negocio.ListarSubCategoriasPorCategoriaId(categoriaId).Select(item => new SelectListItem { Value = item.Id.ToString(CultureInfo.InvariantCulture), Text = item.Descripcion }).ToList();
        }

        [HttpGet]
        public JsonResult ListarSubcategorias(int categoriaId)
        {
            var subcategorias = Negocio.ListarSubCategoriasPorCategoriaId(categoriaId);
            return Json(subcategorias.ToList());
        }
    }
}
