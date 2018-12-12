using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeSet.Models;
using HomeSet.Negocio;
using HomeSet.Domain.Dto;
using HomeSet.Domain.Entidades;
using HomeSet.Domain;
using HomeSet.Domain.Atributos;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Linq.Expressions;
using System;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace HomeSet.Controllers
{
    [Authorize]
    public class RolController : Controller
    {
        private readonly RoleManager<Rol> RoleManager;
        private readonly IMapper Mapper;

        public RolController(RoleManager<Rol> roleManager, IMapper mapper)
        {
            RoleManager = roleManager;
            Mapper = mapper;
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
        public async Task<IActionResult> Crear(RolDto dto)
        {
            if (ModelState.IsValid)
            {
                //if (await RoleManager.RoleExistsAsync(dto.Nombre))
                //{
                //    ModelState.AddModelError(string.Empty, "Ya existe un Rol con ese nombre");
                //    return View(dto);
                //}
                var rol = new Rol { Name = dto.Nombre };
                var resultado = await RoleManager.CreateAsync(rol);
                if (resultado.Succeeded)
                {
                    return new AjaxEditSuccessResult();
                }
                AddErrors(resultado);
            }
            return View(dto);
        }        

        [HttpGet]
        public IActionResult Crear()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            var rol = await RoleManager.FindByIdAsync(id.ToString());
            var resultado = await RoleManager.DeleteAsync(rol);
            return Content(!resultado.Errors.Any() ? "true" : resultado.Errors.FirstOrDefault().Description);            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private ListaPaginada<RolDto> ListQuery(string filtro, int pagina, string ordenarPor, DirOrden dirOrden)
        {
            var paginacion = new Paginacion(ordenarPor, dirOrden, pagina, 10);
            var rolesQuery = RoleManager.Roles;

            Expression<Func<Rol, bool>> expresionFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                filtro = filtro.Trim();
                expresionFiltro = x => x.Name.Contains(filtro);
            }

            if (expresionFiltro != null)
            {
                rolesQuery = rolesQuery.Where(expresionFiltro);
            }

            int itemsTotales = rolesQuery.Count();

            if (paginacion.OrdenarPor != null)
            {
                rolesQuery.OrderBy(paginacion.OrdenarPor, paginacion.DireccionOrden == DirOrden.Asc);
            }

            rolesQuery = rolesQuery.Skip((paginacion.Pagina - 1) * paginacion.ItemsPorPagina).Take(paginacion.ItemsPorPagina);
            var itemsDto = Mapper.Map<IList<RolDto>>(rolesQuery.ToList());

            return new ListaPaginada<RolDto>(itemsDto, paginacion.Pagina, paginacion.ItemsPorPagina, itemsTotales);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    }
}
