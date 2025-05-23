﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.TipoServicios.Listar;
using ThomasSalon.Abstracciones.Modelos.Servicios;
using ThomasSalon.LN.Servicios.CambiarEstado;
using ThomasSalon.LN.Servicios.Editar;
using ThomasSalon.LN.Servicios.Listar;
using ThomasSalon.LN.Servicios.ObtenerPorId;
using ThomasSalon.LN.Servicios.Registrar;
using ThomasSalon.LN.TipoServicios.Listar;

namespace ThomasSalon.UI.Controllers
{
    public class ServiciosController : Controller
    {
        IListarServiciosLN _listarServicios;
        IRegistrarServiciosLN _registrarServicios;
        IEditarServiciosLN _editarServicios;
        ICambiarEstadoServiciosLN _cambiarEstado;
        IObtenerServiciosPorIdLN _obtenerServiciosPorId;
        IListarTipoServiciosLN _listarTipoServicios;

        public ServiciosController()
        {
            _listarServicios = new ListarServiciosLN();
            _registrarServicios = new RegistrarServiciosLN();
            _editarServicios = new EditarServiciosLN();
            _cambiarEstado = new CambiarEstadoServiciosLN();
            _obtenerServiciosPorId = new ObtenerServiciosPorIdLN();
            _listarTipoServicios = new ListarTipoServiciosLN();
        }

        // GET: Servicios

        public ActionResult ListarServicios()
        {
            List<ServiciosDto> laListaDeServicios = _listarServicios.Listar();
            return View(laListaDeServicios);
        }
        // GET: Servicios
        public ActionResult Servicios()
        {
            List<ServiciosDto> laListaDeServicios = _listarServicios.ListarActivos();
            return View(laListaDeServicios);
        }

        // GET: Servicios
        public ActionResult ObtenerServiciosParcial()
        {
            List<ServiciosDto> laListaDeServicios = _listarServicios.Listar();
            return PartialView("_Servicios", laListaDeServicios);
        }

        // GET: Servicios/Details/5
        public ActionResult DetalleServicio(int id)
        {
            ServiciosDto servicios = _obtenerServiciosPorId.Obtener(id);
            return View(servicios);
        }




        // GET: Servicios/Create
        [Authorize(Roles = "Gerente")]
        public ActionResult Create()
        {
            var listaTiposServicio = _listarTipoServicios.Listar();
            ViewBag.TiposServicios = new SelectList(listaTiposServicio, "IdTipoServicios", "Nombre");
            return View();
        }

        // POST: Servicios/Create
        [Authorize(Roles = "Gerente")]
        [HttpPost]
        public async Task<ActionResult> Create(ServiciosDto modelo)
        {
            try
            {
                int cantidadDeDatosGuardados = await _registrarServicios.Registrar(modelo);
                return RedirectToAction("ListarServicios");
            }
            catch
            {
                var listaTiposServicio = _listarTipoServicios.Listar();
                ViewBag.TiposServicios = new SelectList(listaTiposServicio, "IdTipoServicios", "Nombre");
                return View(modelo);
            }
        }



        // GET: Servicios/Edit/5
        [Authorize(Roles = "Gerente")]
        public ActionResult Edit(int id)
        {
            ServiciosDto elServicio = _obtenerServiciosPorId.Obtener(id);

            var listaTiposServicio = _listarTipoServicios.Listar();
            ViewBag.TiposServicios = new SelectList(listaTiposServicio, "IdTipoServicios", "Nombre");

            return View(elServicio);
        }

        [Authorize(Roles = "Gerente")]
        // POST: Servicios/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ServiciosDto elServicio)
        {
            try
            {
                var listaTiposServicio = _listarTipoServicios.Listar();
                ViewBag.TiposServicios = new SelectList(listaTiposServicio, "IdTipoServicios", "Nombre");

                int cantidadDeDatosEditados = await _editarServicios.Editar(elServicio);
                return RedirectToAction("ListarServicios");
            }
            catch
            {
                var listaTiposServicio = _listarTipoServicios.Listar();
                ViewBag.TiposServicios = new SelectList(listaTiposServicio, "IdTipoServicios", "Nombre");
                return View(elServicio);
            }
        }

        [Authorize(Roles = "Gerente")]
        public async Task<ActionResult> Activar(int id)
        {
            int resultado = await _cambiarEstado.CambiarEstado(id, 1); // Cambiar a estado "Activo"
            return RedirectToAction("ListarServicios");
        }
        [Authorize(Roles = "Gerente")]
        public async Task<ActionResult> Inactivar(int id)
        {
            int resultado = await _cambiarEstado.CambiarEstado(id, 2); // Cambiar a estado "Inactivo"
            return RedirectToAction("ListarServicios");
        }
    }
}
