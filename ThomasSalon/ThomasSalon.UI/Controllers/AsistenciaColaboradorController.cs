using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.AsistenciaColaboradores.AgregarAsistencia;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.AsistenciaColaboradores.AgregarAsistencia;
using ThomasSalon.AccesoADatos;
using ThomasSalon.LN.AsistenciaColaboradores.AgregarAsistencia;
using ThomasSalon.LN.Colaboradores.Listar;
using ThomasSalon.LN.Sucursales.Listar;
using ThomasSalon.LN.Usuarios.ObtenerPorId;

namespace ThomasSalon.UI.Controllers
{
    public class AsistenciaColaboradorController : Controller
    {
        private readonly Contexto _elContexto;
        IAgregarAsistenciaLN _agregarAsistenciaLN;
        IListarColaboradoresLN _listarColaboradoresLN;
        IListarSucursalesLN _listarSucursales;
        IObtenerUsuariosPorIdLN _obtenerUsuarioPorId;

        public AsistenciaColaboradorController()
        {
            _elContexto = new Contexto();
            _obtenerUsuarioPorId = new ObtenerUsuariosPorIdLN();

            _agregarAsistenciaLN = new AgregarAsistenciaLN();
            _listarColaboradoresLN = new ListarColaboradoresLN();
            _listarSucursales = new ListarSucursalesLN();
        }
        // GET: AsistenciaColaborador
        public ActionResult Index()
        {
            return View();
        }

        // GET: AsistenciaColaborador/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AsistenciaColaborador/Create
        public async Task<ActionResult> AgregarAsistencia()
        {
            var userId = User.Identity.GetUserId();
            var usuarioActual = _obtenerUsuarioPorId.Obtener(userId);

            var modelo = new AsistenciaColaboradorDTO();

            if (usuarioActual.IdSucursal.HasValue)
            {
                modelo.IdSucursal = usuarioActual.IdSucursal.Value;
            }
            else
            {
                ModelState.AddModelError("", "No se pudo determinar la sucursal del usuario.");
            }

            var tipoJornada = await _elContexto.TipoJornadaTabla.ToListAsync();
            ViewBag.TipoJornada = new SelectList(tipoJornada, "IdTipoJornada", "Nombre");

            var colaboradores = _listarColaboradoresLN.ListarDisponibles();
            ViewBag.Colaboradores = new SelectList(colaboradores, "IdColaborador", "Nombre");

            return View(modelo); // Enviamos el modelo con el IdSucursal seteado
        }


        // POST: AsistenciaColaborador/Create
        [HttpPost]
        public async Task<ActionResult> AgregarAsistencia(AsistenciaColaboradorDTO modelo)
        {
            var userId = User.Identity.GetUserId();
            var usuarioActual = _obtenerUsuarioPorId.Obtener(userId);

            if (usuarioActual.IdSucursal.HasValue)
            {
                modelo.IdSucursal = usuarioActual.IdSucursal.Value;
            }
            else
            {
                ModelState.AddModelError("", "No se pudo determinar la sucursal del usuario.");
                return View(modelo);
            }

            var colaboradores = _listarColaboradoresLN.ListarDisponibles();
            ViewBag.Colaboradores = new SelectList(colaboradores, "IdColaborador", "Nombre");

            var tipoJornada = await _elContexto.TipoJornadaTabla.ToListAsync();
            ViewBag.TipoJornada = new SelectList(tipoJornada, "IdTipoJornada", "Nombre");

            if (!ModelState.IsValid)
            {
                // Agrega todos los errores al ModelState manualmente para depuración
                foreach (var key in ModelState.Keys)
                {
                    var errors = ModelState[key].Errors;
                    foreach (var error in errors)
                    {
                        // Esto es útil si estás logueando errores o quieres mostrarlos en la vista
                        ModelState.AddModelError("", $"Error en el campo '{key}': {error.ErrorMessage}");
                    }
                }

                return View(modelo);
            }

            try
            {
                var resultado = await _agregarAsistenciaLN.AgregarAsistencia(modelo);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", $"Error al guardar la asistencia: {ex.Message}");
                return View(modelo);
            }
        }


        // GET: AsistenciaColaborador/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: AsistenciaColaborador/Edit/5
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

        // GET: AsistenciaColaborador/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: AsistenciaColaborador/Delete/5
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
