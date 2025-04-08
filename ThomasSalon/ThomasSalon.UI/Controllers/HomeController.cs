using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.AccesoADatos.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.AccesoADatos.Usuarios.ObtenerPorId;
using ThomasSalon.LN.Sucursales.Listar;

namespace ThomasSalon.UI.Controllers
{
    public class HomeController : Controller
    {
        IListarSucursalesLN _listarSucursales;
        IObtenerUsuariosPorIdAD _obtenerUsuarioPorId;
        public HomeController()
        {
            _listarSucursales = new ListarSucursalesLN();
            _obtenerUsuarioPorId = new ObtenerUsuariosPorIdAD();
        }


        //public PartialViewResult CargarSucursales()
        //{
        //    List<SucursalesDto> sucursales = _listarSucursales.ListarActivas();
        //    return PartialView("_DropdownSucursales", sucursales);
        //}

        public PartialViewResult CargarSucursalesInventarios()
        {
            try
            {
                var userId = User.Identity.GetUserId();
                var usuarioActual = _obtenerUsuarioPorId.Obtener(userId);

                if (usuarioActual == null)
                {
                    throw new Exception("No se encontró el usuario autenticado.");
                }

                List<SucursalesDto> sucursalesInventarios = _listarSucursales.ListarSucursalesActivas();

                if (User.IsInRole("Administrador"))
                {
                    // Validar si el usuario tiene una sucursal asignada
                    if (usuarioActual.IdSucursal == null)
                    {
                        throw new Exception("El administrador no tiene una sucursal asignada.");
                    }


                    sucursalesInventarios = _listarSucursales.ListarSucursalesActivas()
                        .Where(s => s.IdSucursal == usuarioActual.IdSucursal)
                        .ToList();
                }
                else if (User.IsInRole("Gerente"))
                {
                    sucursalesInventarios = _listarSucursales.ListarSucursalesActivas();
                }

                return PartialView("_DropdownSucursalesInventarios", sucursalesInventarios);

            }
            catch
            {
                return PartialView("_DropdownSucursalesInventarios", new List<SucursalesDto>());

            }
           
        }



        public PartialViewResult CargarSucursalesAgendas()
        {
            try
            {
                var userId = User.Identity.GetUserId(); 
                var usuarioActual = _obtenerUsuarioPorId.Obtener(userId); 

                if (usuarioActual == null)
                {
                    throw new Exception("No se encontró el usuario autenticado.");
                }

                List<SucursalesDto> sucursalesAgendas = new List<SucursalesDto>();

                if (User.IsInRole("Administrador"))
                {
                    // Validar si el usuario tiene una sucursal asignada
                    if (usuarioActual.IdSucursal == null)
                    {
                        throw new Exception("El administrador no tiene una sucursal asignada.");
                    }


                    sucursalesAgendas = _listarSucursales.ListarSucursalesActivas()
                        .Where(s => s.IdSucursal == usuarioActual.IdSucursal)
                        .ToList();
                }
                else if (User.IsInRole("Gerente"))
                {
                    sucursalesAgendas = _listarSucursales.ListarSucursalesActivas();
                }

                return PartialView("_DropdownSucursalesAgendas", sucursalesAgendas);
            }
            catch (Exception ex)
            {                
                return PartialView("_DropdownSucursalesAgendas", new List<SucursalesDto>());
            }
        }
       


        public ActionResult Index()
        {
            if (User.IsInRole("Administrador") || User.IsInRole("Gerente"))
            {
                return RedirectToAction("Dashboard");
            }

            return View();
        }

        public ActionResult Dashboard()
        {
            return View();
        }






        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}