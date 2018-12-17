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
    public class CategoriaController : Controller
    {
        private readonly INegocio Negocio;

        public CategoriaController(INegocio negocio)
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
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Crear(CategoriaDto dto)
        {
            if (ModelState.IsValid)
            {
                var resultado = Negocio.AltaCategoria(dto);
                if (!resultado.HayErrores)
                {
                    return new AjaxEditSuccessResult();
                }
                ModelState.AgregarErrores(resultado);
            }
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Modificar(CategoriaDto dto)
        {
            if (ModelState.IsValid)
            {
                var resultado = Negocio.ModificarCategoria(dto);
                if (!resultado.HayErrores)
                {
                    return new AjaxEditSuccessResult();
                }
                ModelState.AgregarErrores(resultado);
            }
            return View(dto);
        }

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Modificar(int id)
        {
            var dto = Negocio.Obtener<Categoria, CategoriaDto>(id);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public IActionResult Eliminar(int id)
        {
            var resultado = Negocio.EliminarCategoria(id);
            return Content(!resultado.HayErrores ? "true" : resultado.Errores.Values.First());            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private ListaPaginada<CategoriaDto> ListQuery(string filtro, int pagina, string ordenarPor, DirOrden dirOrden)
        {
            var paginacion = new Paginacion(ordenarPor, dirOrden, pagina, 10);

            return Negocio.ListarCategoriasPaginado(filtro, paginacion);
        }
    }
}
