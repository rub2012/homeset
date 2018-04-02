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

namespace HomeSet.Controllers
{
    public class SubCategoriaController : Controller
    {
        private readonly INegocio Negocio;

        public SubCategoriaController(INegocio negocio)
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
            return View(ListQuery("", 1, "Id", DirOrden.Asc));
        }

        [HttpPost]
        public IActionResult Crear(SubCategoriaDto dto)
        {
            if (ModelState.IsValid)
            {
                var resultado = Negocio.AltaSubCategoria(dto);
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
        public IActionResult Modificar(SubCategoriaDto dto)
        {
            if (ModelState.IsValid)
            {
                var resultado = Negocio.ModificarSubCategoria(dto);
                if (!resultado.HayErrores)
                {
                    return new AjaxEditSuccessResult();
                }
                ModelState.AgregarErrores(resultado);
            }
            CargarCategorias();
            return View(dto);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            //var dto = new EventoDto { Fecha = DateTime.Now };
            CargarCategorias();
            return View();
        }

        [HttpGet]
        public IActionResult Modificar(int id)
        {
            var dto = Negocio.Obtener<SubCategoria, SubCategoriaDto>(id);
            CargarCategorias();
            return View(dto);
        }

        [HttpPost]
        public IActionResult Eliminar(int id)
        {
            var resultado = Negocio.EliminarSubCategoria(id);
            return Content(!resultado.HayErrores ? "true" : resultado.Errores.Values.First());            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private ListaPaginada<SubCategoriaDto> ListQuery(string filtro, int pagina, string ordenarPor, DirOrden dirOrden)
        {
            var paginacion = new Paginacion(ordenarPor, dirOrden, pagina, 10);

            return Negocio.ListarSubCategoriasPaginado(filtro, paginacion);
        }

        private void CargarCategorias()
        {
            ViewBag.Categorias = Negocio.ListarCategorias().Select(item => new SelectListItem { Value = item.Id.ToString(CultureInfo.InvariantCulture), Text = item.Descripcion }).ToList();
        }
    }
}
