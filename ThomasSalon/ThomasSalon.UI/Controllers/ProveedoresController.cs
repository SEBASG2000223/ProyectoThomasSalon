using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.Registrar;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.Abstracciones.Modelos.Proveedores;
using ThomasSalon.LN.Proveedores.CambiarEstado;
using ThomasSalon.LN.Proveedores.Editar;
using ThomasSalon.LN.Proveedores.Listar;
using ThomasSalon.LN.Proveedores.ObtenerPorId;
using ThomasSalon.LN.Proveedores.Registrar;

namespace ThomasSalon.UI.Controllers
{
    [Authorize(Roles = "Gerente")]
    public class ProveedoresController : Controller
    {
        IListarProveedoresLN _listarProveedores;
        IRegistrarProveedoresLN _registrarProveedores;
        IEditarProveedoresLN _editarProveedores;
        ICambiarEstadoProveedoresLN _cambiarEstado;
        IObtenerProveedoresPorIdLN _obtenerProveedoresPorId;
        public ProveedoresController()
        {
            _listarProveedores = new ListarProveedoresLN();
            _registrarProveedores = new RegistrarProveedoresLN();
            _editarProveedores = new EditarProveedoresLN();
            _cambiarEstado = new CambiarEstadoProveedoresLN();
            _obtenerProveedoresPorId = new ObtenerProveedoresPorIdLN();

        }
       
        // GET: Proveedores
        public ActionResult ListarProveedores()
        {
            List<ProveedoresDto> laListaDeProveedores = _listarProveedores.Listar();
            return View(laListaDeProveedores);
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProveedoresDto modelo)
        {
            try
            {
                int cantidadDeDatosGuardados = await _registrarProveedores.Registrar(modelo);

                if (cantidadDeDatosGuardados == 0)
                {
                    TempData["Error"] = "Ya existe un proveedor con este nombre.";
                    return RedirectToAction("Create"); 
                }

              
                return RedirectToAction("ListarProveedores");
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Create");
            }
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(int id)
        {
            ProveedoresDto elProveedor = _obtenerProveedoresPorId.Obtener(id);
            return View(elProveedor);
        }

        // POST: Proveedores/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ProveedoresDto laScursal)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarProveedores.Editar(laScursal);

                return RedirectToAction("ListarProveedores");
            }
            catch
            {
                return View("ListarProveedores");
            }
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Proveedores/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("ListarProveedores");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Activar(int id)
        {

            int resultado = await _cambiarEstado.CambiarEstado(id, 1);

            return RedirectToAction("ListarProveedores");




        }

        public async Task<ActionResult> Inactivar(int id)
        {

            int resultado = await _cambiarEstado.CambiarEstado(id, 2);
            return RedirectToAction("ListarProveedores");



        }
    }
}
