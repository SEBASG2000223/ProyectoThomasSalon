using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Sucursales.Registrar;
using ThomasSalon.Abstracciones.Modelos.Sucursales;
using ThomasSalon.LN.Sucursales.CambiarEstado;
using ThomasSalon.LN.Sucursales.Editar;
using ThomasSalon.LN.Sucursales.Listar;
using ThomasSalon.LN.Sucursales.ObtenerPorId;
using ThomasSalon.LN.Sucursales.Registrar;

namespace ThomasSalon.UI.Controllers
{
    public class SucursalesController : Controller
    {
        IListarSucursalesLN _listarSucursales;
        IRegistrarSucursalesLN _registrarSucursales;
        IEditarSucursalesLN _editarSucursales;
        ICambiarEstadoSucursalesLN _cambiarEstado;
        IObtenerSucursalesPorIdLN _obtenerSucursalesPorId;  

        public SucursalesController()
        {
            _listarSucursales = new ListarSucursalesLN();
            _registrarSucursales = new RegistrarSucursalesLN();
            _editarSucursales = new EditarSucursalesLN();
            _cambiarEstado = new CambiarEstadoSucursalesLN();
            _obtenerSucursalesPorId = new ObtenerSucursalesPorIdLN();

        }
        // GET: Sucursales
        public ActionResult ListarSucursales()
        {
            List<SucursalesDto> laListaDeSucursales = _listarSucursales.Listar();
            return View(laListaDeSucursales);
        }

        //GET: Sucursalres
        public ActionResult Sucursales()
        {
            List<SucursalesDto> laListaDeSucursales = _listarSucursales.Listar();
            return View(laListaDeSucursales);
        }
        
        // GET: Sucursales
        public ActionResult ObtenerSucursalesParcial()
        {
            List<SucursalesDto> laListaDeSucursales = _listarSucursales.Listar();
            return PartialView("_Sucursales", laListaDeSucursales);
        }

        // GET: Sucursales/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sucursales/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sucursales/Create
        [HttpPost]
        public async Task<ActionResult> Create(SucursalesDto modelo)
        {
            try
            {
                int cantidadDeDatosGuardados = await _registrarSucursales.Registrar(modelo);
              

                return RedirectToAction("ListarSucursales");
            }
            catch
            {
                return View();
            }
        }

        // GET: Sucursales/Edit/5
        public ActionResult Edit(int id)
        {
            SucursalesDto laSucursal = _obtenerSucursalesPorId.Obtener(id);
            return View(laSucursal);
        }

        // POST: Sucursales/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(SucursalesDto laSucursal)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarSucursales.Editar(laSucursal);


                return RedirectToAction("ListarSucursales");
            }
            catch
            {
                return View("ListarSucursales");
            }
        }

        // GET: Sucursales/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Sucursales/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("ListarSucursales");
            }
            catch
            {
                return View();
            }
        }
        public async Task<ActionResult> Activar(int id)
        {
            
                int resultado = await _cambiarEstado.CambiarEstado(id, 1);

                  return RedirectToAction("ListarSucursales");
                
               
            
          
        }

        public async Task<ActionResult> Inactivar(int id)
        {
            
                int resultado = await _cambiarEstado.CambiarEstado(id, 2);
            return RedirectToAction("ListarSucursales");



        }

        

    }
}
