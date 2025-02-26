using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Colaboradores.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.Usuarios.QuitarUsuarios;
using ThomasSalon.Abstracciones.Modelos.Colaboradores;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.LN.Colaboradores.CambiarEstado;
using ThomasSalon.LN.Colaboradores.Editar;
using ThomasSalon.LN.Colaboradores.Listar;
using ThomasSalon.LN.Colaboradores.ObtenerPorId;
using ThomasSalon.LN.Colaboradores.Registrar;
using ThomasSalon.LN.Personas.Editar;
using ThomasSalon.LN.Personas.ObtenerPorId;
using ThomasSalon.LN.Personas.Registrar;
using ThomasSalon.LN.Usuarios.QuitarUsuarios;

namespace ThomasSalon.UI.Controllers
{
    public class ColaboradoresController : Controller
    {
        IListarColaboradoresLN _listarColaboradores;
        IRegistrarColaboradoresLN _registrarColaboradores;
        IEditarColaboradoresLN _editarColaboradores;
        ICambiarEstadoColaboradoresLN _cambiarEstado;
        IObtenerColaboradoresPorIdLN _obtenerColaboradoresPorId;
        IRegistrarPersonasLN _registrarPersonas;
        IQuitarUsuariosLN _quitarUsuariosLN;
        IObtenerPersonasPorIdLN _obtenerPersonasPorId;
        IEditarPersonasLN _editarPersonasLN;

        public ColaboradoresController()
        {
            _listarColaboradores = new ListarColaboradoresLN();
            _registrarColaboradores = new RegistrarColaboradoresLN();
            _editarColaboradores = new EditarColaboradoresLN();
            _cambiarEstado = new CambiarEstadoColaboradoresLN();
            _obtenerColaboradoresPorId = new ObtenerColaboradoresPorIdLN();
            _registrarPersonas = new RegistrarPersonasLN();
            _quitarUsuariosLN = new QuitarUsuariosLN();
            _obtenerPersonasPorId = new ObtenerPersonasPorIdLN();
            _editarPersonasLN = new EditarPersonasLN();
        }


        // GET: Colaboradores
        public ActionResult ListarColaboradores()
        {
            List<ColaboradoresDto> laListaDeColaboradores = _listarColaboradores.Listar();
            return View(laListaDeColaboradores);
        }


        // GET: Colaboradores/Details/5
        public ActionResult Details(int id)
        {
            ColaboradoresDto elColaborador = _obtenerColaboradoresPorId.Obtener(id);
            return View(elColaborador);
        }

        // GET: Colaboradores/Create
        public ActionResult Create()
        {
            ColaboradoresDto modelo = new ColaboradoresDto
            {
                IdEstado = 1
            };

            return View(modelo);
        }

        // POST: Colaboradores/Create
        [HttpPost]
        public async Task<ActionResult> Create(ColaboradoresDto modelo)
        {
            try
            {
                if (modelo.Persona != null)
                {
                    // Primero registrar la persona
                    int idPersona = await _registrarPersonas.Registrar(modelo.Persona);



                    // Asignar el ID de la persona al colaborador
                    modelo.IdPersona = idPersona;
                }

                // Registrar el colaborador
                int cantidadDeDatosGuardados = await _registrarColaboradores.Registrar(modelo);

                return RedirectToAction("ListarColaboradores");
            }
            catch
            {
                return View();
            }
        }

        // GET: Colaboradores/Edit/5
        public ActionResult Edit(int id)
        {
            ColaboradoresDto elColaborador = _obtenerColaboradoresPorId.Obtener(id);

            elColaborador.IdEstado = 1;

            return View(elColaborador);
        }



        // POST: Colaboradores/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ColaboradoresDto elColaborador)
        {
            try
            {
                await _editarColaboradores.Editar(elColaborador);
                if (elColaborador.Persona != null)
                {
                    await _editarPersonasLN.Editar(elColaborador.Persona);
                }
                return RedirectToAction("ListarColaboradores");
            }
            catch
            {
                return View("ListarColaboradores");
            }
        }

        // GET: Colaboradores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Colaboradores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // Agregar lógica de eliminación aquí
                return RedirectToAction("ListarColaboradores");
            }
            catch
            {
                return View();
            }
        }

        // Activar Colaborador
        public async Task<ActionResult> QuitarUsuario(int idUsuario)
        {
            int resultado = await _quitarUsuariosLN.EliminarUsuario(idUsuario);
            return RedirectToAction("ListarColaboradores");
        }

        // Activar Colaborador
        public async Task<ActionResult> Activar(int id)
        {
            int resultado = await _cambiarEstado.CambiarEstado(id, 1);
            return RedirectToAction("ListarColaboradores");
        }

        // Inactivar Colaborador
        public async Task<ActionResult> Inactivar(int id)
        {
            int resultado = await _cambiarEstado.CambiarEstado(id, 2);
            return RedirectToAction("ListarColaboradores");
        }
    }
}

