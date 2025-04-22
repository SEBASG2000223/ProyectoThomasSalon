using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas.Agendar;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Citas.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Servicios.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.ObtenerPorId;
using ThomasSalon.Abstracciones.Modelos.Citas;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.AccesoADatos;
using ThomasSalon.LN.Citas.Agendar;
using ThomasSalon.LN.Citas.CambiarEstado;
using ThomasSalon.LN.Citas.Listar;
using ThomasSalon.LN.Citas.ObtenerPorId;
using ThomasSalon.LN.Colaboradores.Listar;
using ThomasSalon.LN.Personas.Listar;
using ThomasSalon.LN.Personas.ObtenerPorId;
using ThomasSalon.LN.Servicios.Listar;
using ThomasSalon.LN.Servicios.ObtenerPorId;
using ThomasSalon.LN.Sucursales.Listar;
using ThomasSalon.LN.Usuarios.ObtenerPorId;

namespace ThomasSalon.UI.Controllers
{
    public class CitasController : Controller
    {
        IListarCitasLN _listarCitas;
        IObtenerCitaPorIdLN _obtenerCitaPorIdLN;
        IObtenerUsuariosPorIdLN _obtenerUsuarioPorId;
        ICambiarEstadoCitaLN _cambiarEstado;
        IObtenerPersonasPorIdLN _obtenerPersonaPorIdLN;
        IAgendarCitasLN _agendarCitaLN;
        IListarServiciosLN _listarServicios;
        IListarColaboradoresLN _listarColaboradores;
        IListarPersonasLN _listarPersona;
        IObtenerServiciosPorIdLN _obtenerServicioPorId;
        IListarSucursalesLN _listarSucursales;
        Contexto _elContexto;


        public CitasController()
        {
            _listarCitas = new ListarCitasLN();
            _obtenerCitaPorIdLN = new ObtenerCitaPorIdLN();
            _cambiarEstado = new CambiarEstadoCitaLN();
            _obtenerUsuarioPorId = new ObtenerUsuariosPorIdLN();
            _obtenerPersonaPorIdLN = new ObtenerPersonasPorIdLN();
            _listarServicios = new ListarServiciosLN();
            _listarColaboradores = new ListarColaboradoresLN();
            _agendarCitaLN = new AgendarCitasLN();
            _listarPersona = new ListarPersonasLN();
            _obtenerServicioPorId = new ObtenerServiciosPorIdLN();
            _listarSucursales = new ListarSucursalesLN();
            _elContexto = new Contexto();

        }

        // GET: Citas
        public ActionResult ListarAgendas(int idSucursal)
        {
            try
            {
                TempData["IdSucursalSeleccionada"] = idSucursal;

                var userId = User.Identity.GetUserId();
                var usuarioActual = _obtenerUsuarioPorId.Obtener(userId);

                if (usuarioActual == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                if (User.IsInRole("Administrador") && usuarioActual.IdSucursal != idSucursal)
                {
                    return View("~/Views/Home/AccesoDenegado.cshtml");
                }

                List<CitasDto> citas = _listarCitas.ListarAgendas(idSucursal);
                TempData.Keep("IdSucursalSeleccionada");
                return View(citas);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al cargar la agenda.";
                return RedirectToAction("Error", "Home");
            }
        }

        public ActionResult ListarCitasUsuario()
        {
            try
            {
                string userId = User.Identity.GetUserId();
                var usuario = _obtenerUsuarioPorId.Obtener(userId);

                if (usuario == null)
                {
                    throw new Exception("Usuario no encontrado.");
                }

                if (User.IsInRole("Usuario") && usuario.IdPersona != usuario.IdPersona)
                {
                    return View("~/Views/Home/AccesoDenegado.cshtml");
                }

                List<CitasDto> citas = _listarCitas.ListarCitasUsuario(usuario.IdPersona);

                return View(citas);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Ocurrió un error al cargar las citas.";
                return RedirectToAction("Error", "Home");
            }
        }


        public JsonResult ObtenerEventos(int idSucursal)
        {
            var eventos = _listarCitas.ListarAgendas(idSucursal)
                .Select(cita => new
                {
                    id = cita.IdCita,
                    title = cita.nombrePersona,
                    start = cita.FechaHora.ToString("yyyy-MM-ddTHH:mm:ss"),
                    end = cita.FechaHora.ToString("yyyy-MM-ddTHH:mm:ss")
                }).ToList();

            return Json(eventos, JsonRequestBehavior.AllowGet);
        }

        public JsonResult BuscarPersonaPorCedula(string cedula)
        {
            var persona = _elContexto.PersonasTabla.FirstOrDefault(p => p.Identificacion == cedula);

            if (persona != null)
            {
                return Json(new { idPersona = persona.IdPersona, nombre = persona.Nombre }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { idPersona = 0, nombre = "" }, JsonRequestBehavior.AllowGet);
        }


        public JsonResult ObtenerHorariosDisponibles(int idServicio, int idSucursal)
        {
            List<string> horariosDisponibles = _agendarCitaLN.ObtenerHorariosDisponibles(idServicio, idSucursal);

            return Json(horariosDisponibles, JsonRequestBehavior.AllowGet);
        }

        // GET: Citas/Details/5
        public ActionResult DetallesCita(Guid IdCita)
        {
            CitasDto cita = _obtenerCitaPorIdLN.DetallesCita(IdCita).FirstOrDefault();
            if (cita == null)
            {
                return HttpNotFound();
            }

            return PartialView("_DetallesCita", cita);
        }

        // GET: Citas/Create
        [Authorize(Roles = "Gerente")]
        public ActionResult AgendarCitaPresencial()
        {
            var idSucursal = TempData["IdSucursalSeleccionada"] != null ? Convert.ToInt32(TempData["IdSucursalSeleccionada"]) : 0;

            var servicios = _listarServicios.ListarActivos();
            ViewBag.servicios = new SelectList(servicios, "IdServicio", "Nombre");

            var colaboradores = _listarColaboradores.ListarActivos();
            var colaboradoresConNoEspecifica = colaboradores.ToList();

            colaboradoresConNoEspecifica.Insert(0, new ColaboradoresDto
            {
                IdColaborador = null,
                Nombre = "No especifica"
            });

            ViewBag.colaboradores = new SelectList(colaboradoresConNoEspecifica, "IdColaborador", "Nombre");


            var duracionesDict = servicios.ToDictionary(s => s.IdServicio.ToString(), s => (int)s.Duracion.TotalMinutes);
            ViewBag.serviciosDuraciones = duracionesDict;

            TempData.Keep("IdSucursalSeleccionada");


            return PartialView("_AgendarCitaPresencial");
        }

        // POST: Citas/Create
        [Authorize(Roles = "Gerente")]
        [HttpPost]
        public async Task<ActionResult> AgendarCitaPresencial(CitasDto modelo)
        {
            try
            {
                var idSucursal = TempData["IdSucursalSeleccionada"] != null ? Convert.ToInt32(TempData["IdSucursalSeleccionada"]) : 0;

                int cantidadDeDatosGuardados = await _agendarCitaLN.AgendarCitaPresencial(modelo, idSucursal);
                TempData.Keep("IdSucursalSeleccionada");

                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                var servicios = _listarServicios.ListarActivos();
                ViewBag.servicios = new SelectList(servicios, "IdServicio", "Nombre");

                var colaboradores = _listarColaboradores.ListarActivos();
                var colaboradoresConNoEspecifica = colaboradores.ToList();
                colaboradoresConNoEspecifica.Insert(0, new ColaboradoresDto
                {
                    IdColaborador = null,
                    Nombre = "No especifica"
                });
                ViewBag.colaboradores = new SelectList(colaboradoresConNoEspecifica, "IdColaborador", "Nombre");

                var duracionesDict = servicios.ToDictionary(s => s.IdServicio.ToString(), s => (int)s.Duracion.TotalMinutes);
                ViewBag.serviciosDuraciones = duracionesDict;

                TempData.Keep("IdSucursalSeleccionada");

                return PartialView("_AgendarCitaPresencial", modelo);
            }

        }


        // GET: Citas/Create
        [Authorize(Roles = "Usuario")]
        public ActionResult AgendarCitaLinea(int idServicio)
        {
            var servicio = _obtenerServicioPorId.Obtener(idServicio);

            var sucursales = _listarSucursales.ListarSucursalesActivas();
            ViewBag.sucursales = new SelectList(sucursales, "IdSucursal", "Nombre");

            var servicios = _listarServicios.ListarActivos();
            ViewBag.servicios = new SelectList(servicios, "IdServicio", "Nombre");

            var colaboradores = _listarColaboradores.ListarActivos();
            var colaboradoresConNoEspecifica = colaboradores.ToList();
            colaboradoresConNoEspecifica.Insert(0, new ColaboradoresDto
            {
                IdColaborador = null,
                Nombre = "No especifica"
            });
            ViewBag.colaboradores = new SelectList(colaboradoresConNoEspecifica, "IdColaborador", "Nombre");

            var duracionesDict = servicios.ToDictionary(s => s.IdServicio.ToString(), s => (int)s.Duracion.TotalMinutes);
            ViewBag.serviciosDuraciones = duracionesDict;

           
            var modelo = new CitasDto
            {
                IdServicio = idServicio  
            };

            return PartialView("_AgendarCitaLinea", modelo);
        }


        // POST: Citas/Create
        [Authorize(Roles = "Usuario")]
        [HttpPost]
        public async Task<ActionResult> AgendarCitaLinea(CitasDto modelo)
        {
            try
            {
                // Obtener el userId
                var userId = User.Identity.GetUserId();
                var idServicio = modelo.IdServicio;

                // Llamar a la lógica de negocio para agendar la cita
                int cantidadDeDatosGuardados = await _agendarCitaLN.AgendarCitaLinea(modelo, userId);

                // Retornar la respuesta JSON
                return Json(new { success = true });
            }
            catch (Exception ex)
            {
                // Manejo de excepciones, cargar nuevamente las listas necesarias
                var sucursales = _listarSucursales.ListarSucursalesActivas();
                ViewBag.sucursales = new SelectList(sucursales, "IdSucursal", "Nombre");

                var servicios = _listarServicios.ListarActivos();
                ViewBag.servicios = new SelectList(servicios, "IdServicio", "Nombre");

                var colaboradores = _listarColaboradores.ListarActivos();
                var colaboradoresConNoEspecifica = colaboradores.ToList();
                colaboradoresConNoEspecifica.Insert(0, new ColaboradoresDto
                {
                    IdColaborador = null,
                    Nombre = "No especifica"
                });
                ViewBag.colaboradores = new SelectList(colaboradoresConNoEspecifica, "IdColaborador", "Nombre");

                var duracionesDict = servicios.ToDictionary(s => s.IdServicio.ToString(), s => (int)s.Duracion.TotalMinutes);
                ViewBag.serviciosDuraciones = duracionesDict;

                // Retornar la vista parcial con el modelo actualizado
                return PartialView("_AgendarCitaLinea", modelo);
            }
        }


        [Authorize(Roles = "Gerente,Administrador, Usuario")]
        public async Task<ActionResult> Cancelar(Guid id)
        {
            var idSucursal = TempData["IdSucursalSeleccionada"] != null ? Convert.ToInt32(TempData["IdSucursalSeleccionada"]) : 0;

            int resultado = await _cambiarEstado.CambiarEstado(id, "Cancelada");

            TempData.Keep("IdSucursalSeleccionada");

            return RedirectToAction("ListarAgendas", new { idSucursal });
        }

        public async Task<ActionResult> CancelarUsuario(Guid id)
        {

            int resultado = await _cambiarEstado.CambiarEstado(id, "Cancelada");

            return RedirectToAction("ListarCitasUsuario");
        }

    }
}
