using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Ventas.ResgistroGastos;
using ThomasSalon.Abstracciones.Modelos.Gastos.ResumenGasto;
using ThomasSalon.Abstracciones.Modelos.Ventas.ResgistroGastos;
using ThomasSalon.AccesoADatos;
using ThomasSalon.LN.Usuarios.ObtenerPorId;
using ThomasSalon.LN.Ventas.ResgistroGastos;

namespace ThomasSalon.UI.Controllers
{
    [Authorize(Roles = "Gerente,Administrador")]
    public class RegistroGastoController : Controller
    {
        private readonly Contexto _elContexto;

        IRegistroGastoLN _registroGasto;
        IObtenerUsuariosPorIdLN _obtenerUsuarioPorId;


        public RegistroGastoController()
        {
            _registroGasto = new RegistroGastoLN();
            _obtenerUsuarioPorId = new ObtenerUsuariosPorIdLN();
            _elContexto = new Contexto();




        }
        // GET: RegistroGasto
        public ActionResult Index()
        {
            return View();
        }

        // GET: RegistroGasto/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        [Authorize(Roles = "Gerente,Administrador")]
        public ActionResult Gastos()
        {
            var hoy = DateTime.Today;

            var gastos = (from g in _elContexto.RegistroGastosTabla
                          join i in _elContexto.IngresosDiariosTabla on g.IdIngreso equals i.IdIngreso
                          join c in _elContexto.ColaboradoresTabla on g.IdColaborador equals c.IdColaborador
                          join p in _elContexto.PersonasTabla on c.IdPersona equals p.IdPersona
                          where DbFunctions.TruncateTime(g.Fecha) == hoy
                          select new GastoResumenDTO
                          {
                              Fecha = g.Fecha,
                              NombreColaborador = p.Nombre,
                              Descripcion = g.Descripcion,
                              Monto = g.Monto
                          }).ToList();

            return View("Gastos", gastos);
        }
        [Authorize(Roles = "Gerente,Administrador")]
        public ActionResult ResumenGastos(DateTime? fechaFiltro)
        {
            var fechaSeleccionada = fechaFiltro ?? DateTime.Today;

            var gastos = (from g in _elContexto.RegistroGastosTabla
                          join c in _elContexto.ColaboradoresTabla on g.IdColaborador equals c.IdColaborador into colaboradorJoin
                          from c in colaboradorJoin.DefaultIfEmpty() 

                          join p in _elContexto.PersonasTabla on c.IdPersona equals p.IdPersona into personaJoin
                          from p in personaJoin.DefaultIfEmpty()

                          where DbFunctions.TruncateTime(g.Fecha) == DbFunctions.TruncateTime(fechaSeleccionada)
                          select new GastoResumenDTO
                          {
                              Fecha = g.Fecha,
                              NombreColaborador = p != null ? p.Nombre : "Sin colaborador",
                              Descripcion = g.Descripcion,
                              Monto = g.Monto
                          }).ToList();

            ViewBag.FechaFiltro = fechaSeleccionada.ToString("yyyy-MM-dd");

            return View("Gastos", gastos);
        }




        // GET: RegistroGasto/Create
        [Authorize(Roles = "Administrador")]
        public ActionResult RegistroGasto()
        {
            var hoy = DateTime.Today;

            var asistenciaConNombre = (from ac in _elContexto.AsistenciaColaboradorTabla
                                       join colab in _elContexto.ColaboradoresTabla on ac.IdColaborador equals colab.IdColaborador
                                       join per in _elContexto.PersonasTabla on colab.IdPersona equals per.IdPersona
                                       where DbFunctions.TruncateTime(ac.Fecha) == hoy
                                       select new
                                       {
                                           IdColaborador = ac.IdColaborador,
                                           Nombre = per.Nombre
                                       }).Distinct().ToList();

            ViewBag.Asistencia = new SelectList(asistenciaConNombre, "IdColaborador", "Nombre");
            return View();
        }

        // POST: RegistroGasto/Create
        [Authorize(Roles = "Administrador")]
        [HttpPost]
        public async Task<ActionResult> RegistroGasto(RegistroGastoDTO registroGasto)
        {
            var userId = User.Identity.GetUserId();
            var usuarioActual = _obtenerUsuarioPorId.Obtener(userId);
            var hoy = DateTime.Today;


            var asistenciaConNombre = (from ac in _elContexto.AsistenciaColaboradorTabla
                                       join colab in _elContexto.ColaboradoresTabla on ac.IdColaborador equals colab.IdColaborador
                                       join per in _elContexto.PersonasTabla on colab.IdPersona equals per.IdPersona
                                       where DbFunctions.TruncateTime(ac.Fecha) == hoy
                                       select new
                                       {
                                           IdColaborador = ac.IdColaborador,
                                           Nombre = per.Nombre
                                       }).Distinct().ToList();

            ViewBag.Asistencia = new SelectList(asistenciaConNombre, "IdColaborador", "Nombre");
            if (usuarioActual.IdSucursal.HasValue)
            {
                registroGasto.IdSucursal = usuarioActual.IdSucursal.Value;
            }
            else
            {
                TempData["Error"] = "No se pudo registrar la venta: el usuario no tiene una sucursal asignada.";
                return View(registroGasto);
            }
            try
            {
                // TODO: Add insert logic here
                var resultado = await _registroGasto.RegistroGasto(registroGasto);

                return RedirectToAction("Gastos");
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroGasto/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RegistroGasto/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: RegistroGasto/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: RegistroGasto/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
