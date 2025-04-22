using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Personas.Registrar;
using ThomasSalon.Abstracciones.Modelos.Personas;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.LN.Personas.Editar;
using ThomasSalon.LN.Personas.Listar;
using ThomasSalon.LN.Personas.ObtenerPorId;
using ThomasSalon.LN.Personas.Registrar;

namespace ThomasSalon.UI.Controllers
{
    [Authorize(Roles = "Gerente,Administrador")]
    public class PersonasController : Controller
    {

        IListarPersonasLN _listarPersonasLN;
        IRegistrarPersonasLN _registrarPersonasLN;
        IEditarPersonasLN _editarPersonasLN;
        IObtenerPersonasPorIdLN _obtenerPersonasPorIdLN;

        public PersonasController()
        {
            _listarPersonasLN = new ListarPersonasLN();
            _registrarPersonasLN = new RegistrarPersonasLN();
            _editarPersonasLN = new EditarPersonasLN();
            _obtenerPersonasPorIdLN = new ObtenerPersonasPorIdLN();
        }
        // GET: Personas
        [Authorize(Roles = "Gerente,Administrador")]
        public ActionResult Index()
        {
            List<PersonasDto> laListaDePersonas = _listarPersonasLN.Listar();
            return View(laListaDePersonas);
        }
        [Authorize(Roles = "Gerente,Administrador")]
        public ActionResult ListarClientes()
        {
            List<PersonasDto> laListaDeClientes = _listarPersonasLN.ListarClientes();
            return View(laListaDeClientes);
        }


        // GET: Personas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Personas/Create
        public ActionResult Create()
        {
            return View();
        }
        [Authorize(Roles = "Gerente,Administrador")]
        // POST: Personas/Create
        [HttpPost]
        public async Task<ActionResult> Create(PersonasDto modelo)
        {
            try
            {
                int cantidadDeDatosGuardados = await _registrarPersonasLN.Registrar(modelo);


                return RedirectToAction("ListarClientes");
            }
            catch
            {
                return View();
            }
        }
        [Authorize(Roles = "Gerente,Administrador")]
        // GET: Personas/Edit/5
        public ActionResult Edit(int id)
        {
            PersonasDto laPersona = _obtenerPersonasPorIdLN.Obtener(id);
            return View(laPersona);
        }
        [Authorize(Roles = "Gerente,Administrador")]
        // POST: Personas/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(PersonasDto laPersona)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarPersonasLN.Editar(laPersona);

                return RedirectToAction("ListarClientes");
            }
            catch
            {
                return View();
            }
        }

        // GET: Personas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Personas/Delete/5
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
