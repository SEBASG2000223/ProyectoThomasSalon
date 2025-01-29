using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.CambiarEstado;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Editar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Listar;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using ThomasSalon.Abstracciones.LN.Interfaces.Productos.Registrar;
using ThomasSalon.Abstracciones.LN.Interfaces.Proveedores.Listar;
using ThomasSalon.Abstracciones.Modelos.Productos;
using ThomasSalon.LN.Productos.CambiarEstado;
using ThomasSalon.LN.Productos.Editar;
using ThomasSalon.LN.Productos.Listar;
using ThomasSalon.LN.Productos.ObtenerPorId;
using ThomasSalon.LN.Productos.Registrar;
using ThomasSalon.LN.Proveedores.Listar;

namespace ThomasSalon.UI.Controllers
{
    public class ProductosController : Controller
    {
        IListarProductosLN _listarProductos;
        IRegistrarProductosLN _registrarProductos;
        IEditarProductosLN _editarProductos;
        ICambiarEstadoProductosLN _cambiarEstado;
        IObtenerProductosPorIdLN _obtenerProductosPorId;
        IListarProveedoresLN _proveedores;
        public ProductosController()
        {
            _listarProductos = new ListarProductosLN();
            _registrarProductos = new RegistrarProductosLN();
            _editarProductos = new EditarProductosLN();
            _cambiarEstado = new CambiarEstadoProductosLN();
            _obtenerProductosPorId = new ObtenerProductosPorIdLN();
            _proveedores = new ListarProveedoresLN();

        }

        // GET: Productos
        public ActionResult ListarProductos()
        {
            List<ProductosDto> laListaDeProductos = _listarProductos.Listar();
            return View(laListaDeProductos);
        }

        // GET: Productos/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            var proveedores = _proveedores.Listar();
            ViewBag.Proveedores = new SelectList(proveedores, "IdProveedor", "Nombre");

            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        public async Task<ActionResult> Create(ProductosDto modelo)
        {
            try
            {
                int cantidadDeDatosGuardados = await _registrarProductos.Registrar(modelo);


                return RedirectToAction("ListarProductos");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int id)
        {
            var proveedores = _proveedores.Listar();
            ViewBag.Proveedores = new SelectList(proveedores, "IdProveedor", "Nombre");

            
            ProductosDto elProducto = _obtenerProductosPorId.Obtener(id);
            return View(elProducto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        public async Task<ActionResult> Edit(ProductosDto elProducto)
        {
            try
            {
                int cantidadDeDatosEditados = await _editarProductos.Editar(elProducto);

                return RedirectToAction("ListarProductos");
            }
            catch
            {
                return View();
            }
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Productos/Delete/5
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
        public async Task<ActionResult> Activar(int id)
        {

            int resultado = await _cambiarEstado.CambiarEstado(id, 1);

            return RedirectToAction("ListarProductos");




        }

        public async Task<ActionResult> Inactivar(int id)
        {

            int resultado = await _cambiarEstado.CambiarEstado(id, 2);
            return RedirectToAction("ListarProductos");



        }
    }
}
