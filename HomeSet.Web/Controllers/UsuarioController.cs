using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using HomeSet.Models;
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
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace HomeSet.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UsuarioController : Controller
    {
        private readonly UserManager<Usuario> UserManager;
        private readonly RoleManager<Rol> RoleManager;
        private readonly IMapper Mapper;

        public UsuarioController(UserManager<Usuario> userManager, RoleManager<Rol> roleManager,IMapper mapper)
        {
            UserManager = userManager;
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
        public async Task<IActionResult> Crear(UsuarioDto dto)
        {
            if (string.IsNullOrEmpty(dto.Password))
            {
                ModelState.AddModelError("Password", "La contraseña es requerida");
                return View(dto);
            }
            if (ModelState.IsValid)
            {
                var roles = !string.IsNullOrEmpty(dto.Rolesjson) ? JsonConvert.DeserializeObject<List<RolDto>>(dto.Rolesjson) : new List<RolDto>();
                var user = Mapper.Map<Usuario>(dto);
                var resultado = await UserManager.CreateAsync(user, dto.Password);                
                if (resultado.Succeeded)
                {
                    foreach (var rol in roles)
                    {
                        if (await RoleManager.RoleExistsAsync(rol.Nombre))
                        {
                            await UserManager.AddToRoleAsync(user, rol.Nombre);
                        }
                    }
                    return new AjaxEditSuccessResult();
                }
                AddErrors(resultado);
            }
            CargarRoles();
            return View(dto);
        }        

        [HttpGet]
        public IActionResult Crear()
        {
            CargarRoles();
            return View(new UsuarioDto());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Modificar(UsuarioDto dto)
        {
            if (ModelState.IsValid)
            {
                var roles = !string.IsNullOrEmpty(dto.Rolesjson) ? JsonConvert.DeserializeObject<List<RolDto>>(dto.Rolesjson) : new List<RolDto>();
                var user = await UserManager.FindByIdAsync(dto.Id.ToString());
                user.Nombre = dto.Nombre;
                user.Apellido = dto.Apellido;

                if (!string.IsNullOrEmpty(dto.Password))
                {
                    var resetToken = await UserManager.GeneratePasswordResetTokenAsync(user);
                    var resultadoReset = await UserManager.ResetPasswordAsync(user, resetToken, dto.Password);
                    if (!resultadoReset.Succeeded)
                    {
                        AddErrors(resultadoReset);
                        CargarRoles();
                        return View(dto);
                    }
                }
                    var resultado = await UserManager.UpdateAsync(user);
                    if (resultado.Succeeded)
                    {
                        var rolesviejos = await UserManager.GetRolesAsync(user);
                        rolesviejos = rolesviejos.Except(roles.Select(s => s.Nombre)).ToList();
                        await UserManager.RemoveFromRolesAsync(user, rolesviejos);
                        foreach (var rol in roles)
                        {
                            if (await RoleManager.RoleExistsAsync(rol.Nombre))
                            {
                                await UserManager.AddToRoleAsync(user, rol.Nombre);
                            }
                        }
                        return new AjaxEditSuccessResult();
                    }
                    AddErrors(resultado);
            }
            CargarRoles();
            return View(dto);
        }

        [HttpGet]
        public async Task<IActionResult> Modificar(int id)
        {
            var usuario = await UserManager.FindByIdAsync(id.ToString());
            CargarRoles();
            var dto = Mapper.Map<UsuarioDto>(usuario);
            return View(dto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Eliminar(int id)
        {
            var usuario = await UserManager.FindByIdAsync(id.ToString());
            var resultado = await UserManager.DeleteAsync(usuario);
            return Content(!resultado.Errors.Any() ? "true" : resultado.Errors.FirstOrDefault().Description);            
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private ListaPaginada<UsuarioDto> ListQuery(string filtro, int pagina, string ordenarPor, DirOrden dirOrden)
        {
            var paginacion = new Paginacion(ordenarPor, dirOrden, pagina, 10);
            var usersQuery = UserManager.Users;

            Expression<Func<Usuario, bool>> expresionFiltro = null;
            if (!string.IsNullOrEmpty(filtro))
            {
                filtro = filtro.Trim();
                expresionFiltro = x => x.Nombre.Contains(filtro)
                || x.Apellido.Contains(filtro)
                || x.UserName.Contains(filtro);
            }

            if (expresionFiltro != null)
            {
                usersQuery = usersQuery.Where(expresionFiltro);
            }

            int itemsTotales = usersQuery.Count();

            if (paginacion.OrdenarPor != null)
            {
                usersQuery.OrderBy(paginacion.OrdenarPor, paginacion.DireccionOrden == DirOrden.Asc);
            }

            usersQuery = usersQuery.Skip((paginacion.Pagina - 1) * paginacion.ItemsPorPagina).Take(paginacion.ItemsPorPagina);
            var itemsDto = Mapper.Map<IList<UsuarioDto>>(usersQuery.ToList());

            return new ListaPaginada<UsuarioDto>(itemsDto, paginacion.Pagina, paginacion.ItemsPorPagina, itemsTotales);
        }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        private void CargarRoles()
        {
            var roles = RoleManager.Roles;
            ViewBag.CargarRoles = roles.Select(item => new SelectListItem { Value = item.Id.ToString(), Text = item.Name }).ToList();
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerRoles(int id)
        {
            if (id == 0)
            {
                return Json(null);
            }
            else
            {
                var roles = new List<Rol>();
                var usuario = await UserManager.FindByIdAsync(id.ToString());
                var rolesString = await UserManager.GetRolesAsync(usuario);
                foreach (var rol in rolesString)
                {
                    roles.Add(await RoleManager.FindByNameAsync(rol));
                }
                var rolesret = roles.Select(item => new SelectListItem { Value = item.Id.ToString(), Text = item.Name }).ToList();
                return Json(rolesret);
            }
            
        }

        [HttpGet]
        public async Task<JsonResult> ObtenerRolesUsuario(int userid)
        {
            if (userid == 0)
            {
                return Json(null);
            }
            else
            {
                var usuario = await UserManager.FindByIdAsync(userid.ToString());
                var rolesString = await UserManager.GetRolesAsync(usuario);
                var roles = RoleManager.Roles.Where(r => rolesString.Any(s => s.Equals(r.Name))).ToList();
                return Json(Mapper.Map<IList<RolDto>>(roles));
            }

        }
    }
}
